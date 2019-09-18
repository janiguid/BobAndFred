using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HighScoreManager highScore;
    GameObject text;
    int score;
    public bool GameOver;
    SpriteRenderer spriteRenderer;
    Animator animator;
    AudioSource audioSource;
    public AudioClip coin;
    public AudioClip slime;

    public bool isFacingRight;
    bool isFacingUp;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("Text");
        score = 0;
        text.GetComponent<TextMesh>().text = score.ToString();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    void Move()
    {

        Vector3 friendPos = PuzzleInitializer.FriendPosition;
        friendPos.z = -1f;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            animator.SetInteger("directionNumber", 0);


            Vector3 potentialPosition = new Vector3(transform.position.x, transform.position.y + 1, 0f);
            if (PuzzleInitializer.walkableDictionary.ContainsKey(potentialPosition))
            {
                potentialPosition = new Vector3(transform.position.x, transform.position.y + 1, -1f);
                transform.position = potentialPosition;
            }
            
            if (transform.position == friendPos)
            {
                ChangeFriendPosition();
                audioSource.PlayOneShot(coin, 0.5f);

                Debug.Log("Found Friend");
            }
            else
            {
                audioSource.PlayOneShot(slime);
            }

            


        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            animator.SetInteger("directionNumber", 1);

            Vector3 potentialPosition = new Vector3(transform.position.x, transform.position.y - 1, 0f);
            if (PuzzleInitializer.walkableDictionary.ContainsKey(potentialPosition))
            {
                potentialPosition = new Vector3(transform.position.x, transform.position.y - 1, -1f);
                transform.position = potentialPosition;
            }

            if (transform.position == friendPos)
            {
                ChangeFriendPosition();
                Debug.Log("Found Friend");
                audioSource.PlayOneShot(coin, 0.5f);
            }
            else
            {
                audioSource.PlayOneShot(slime);
            }

            

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            animator.SetInteger("directionNumber", 3);

            Vector3 potentialPosition = new Vector3(transform.position.x - 1, transform.position.y, 0f);
            if (PuzzleInitializer.walkableDictionary.ContainsKey(potentialPosition))
            {
                potentialPosition = new Vector3(transform.position.x - 1, transform.position.y, -1f);
                transform.position = potentialPosition;
            }

            if (transform.position == friendPos)
            {
                ChangeFriendPosition();
                Debug.Log("Found Friend");
                audioSource.PlayOneShot(coin, 0.5f);
            }
            else
            {
                audioSource.PlayOneShot(slime);
            }

            

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {


            animator.SetInteger("directionNumber", 2);

            Vector3 potentialPosition = new Vector3(transform.position.x + 1, transform.position.y, 0f);
            if (PuzzleInitializer.walkableDictionary.ContainsKey(potentialPosition))
            {
                potentialPosition = new Vector3(transform.position.x + 1, transform.position.y, -1f);
                transform.position = potentialPosition;
            }

            if (transform.position == friendPos)
            {
                ChangeFriendPosition();
                Debug.Log("Found Friend");
                audioSource.PlayOneShot(coin, 0.5f);
            }
            else
            {
                audioSource.PlayOneShot(slime);
            }
            
        }
    }

    void FlipVertical()
    {
        Vector3 flipper = transform.localScale;
        flipper.y *= -1f;
        transform.localScale = flipper;
    }

    void FlipHorizontal()
    {
        Vector3 flipper = transform.localScale;
        flipper.x *= -1f;
        transform.localScale = flipper;
    }

    void ChangeFriendPosition()
    {
        PuzzleInitializer.ActualFriend.transform.position = GetRandomPosition();
        PuzzleInitializer.FriendPosition = PuzzleInitializer.ActualFriend.transform.position;
        GetComponentInChildren<LightScript>().IncrementScale();
        ++score;
        if(score > highScore.getScore())
        {
            highScore.setHighScore(score);
        }
        text.GetComponent<TextMesh>().text = score.ToString();
    }

    Vector3 GetRandomPosition()
    {
        int x = Random.Range(-5, 5);
        float realX = x + 0.5f;
        int y = Random.Range(-8, 9);
        float realY = y + 0.5f;
        Debug.Log(realX);
        Debug.Log(realY);
        Vector3 potentialVector = new Vector3(realX, realY, 0);

        while (!PuzzleInitializer.walkableDictionary.ContainsKey(potentialVector))
        {
            int ex = Random.Range(-5, 5);
            float realEX = ex + 0.5f;
            int wy = Random.Range(-5, 5);
            float realWY = wy + 0.5f;
            potentialVector = new Vector3(realEX, realWY, 0);
            Debug.Log("Doesn't contain: " + potentialVector);
        }

        Debug.Log("Success!");
        potentialVector.z = -1;
        return potentialVector;
    }
}
