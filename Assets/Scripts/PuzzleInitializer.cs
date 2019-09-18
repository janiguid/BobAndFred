using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInitializer : MonoBehaviour
{
    public GameObject Space;
    public GameObject Wall;
    public GameObject Friend;
    public GameObject Player;
    

    public static GameObject ActualFriend;

    public float ySize =7.5f;
    public float xSize =4.5f;

    public static Dictionary<Vector3, bool> walkableDictionary = new Dictionary<Vector3, bool>();
    public static Vector3 FriendPosition;

    public Transform PuzzleHolder;
    //rotated 180 degrees to the left
    private int[] layout = new int[160]
        {
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
            1, 0, 0, 0, 1, 0, 0, 1, 0, 1,
            1, 1, 0, 1, 1, 1, 1, 1, 0, 1,
            1, 0, 0, 1, 0, 0, 0, 1, 0, 1,
            1, 0, 1, 1, 1, 1, 0, 0, 0, 1,
            1, 0, 0, 0, 0, 0, 0, 1, 1, 1,
            1, 1, 1, 1, 0, 2, 1, 1, 0, 1,
            1, 0, 0, 1, 0, 0, 0, 0, 0, 1,
            1, 0, 1, 1, 1, 0, 1, 1, 1, 1,
            1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
            1, 1, 1, 0, 1, 1, 1, 1, 0, 1,
            1, 0, 1, 0, 1, 0, 1, 0, 0, 1,
            1, 0, 1, 0, 1, 0, 1, 0, 1, 1,
            1, 0, 0, 0, 0, 0, 1, 0, 0, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1
        };
    // Start is called before the first frame update
    void Start()
    {
        InitializePuzzle();
        InitializeFriend();
    }


    void InitializePuzzle()
    {
        int nodeNumber = 0;
        for(float i = -ySize; i <= ySize; ++i)
        {
            for(float j = -xSize; j <= xSize; ++j)
            {
                if(layout[nodeNumber] == 0)
                {
                    //Space
                    GameObject newNode = Instantiate(Space, PuzzleHolder);
                    newNode.GetComponent<Node>().position = new Vector3(i, j, 0f);
                    newNode.transform.position = newNode.GetComponent<Node>().position;
                    walkableDictionary.Add(newNode.GetComponent<Node>().position, true);
                }else if(layout[nodeNumber] == 1)
                {
                    //Wall
                    GameObject newNode = Instantiate(Wall, PuzzleHolder);
                    newNode.GetComponent<Node>().position = new Vector3(i, j);
                    newNode.transform.position = newNode.GetComponent<Node>().position;
                }
                else
                {
                    //Player
                    GameObject newNode = Instantiate(Space, PuzzleHolder);
                    newNode.GetComponent<Node>().position = new Vector3(i, j, 0f);
                    newNode.transform.position = newNode.GetComponent<Node>().position;
                    walkableDictionary.Add(newNode.GetComponent<Node>().position, true);
                    GameObject player = Instantiate(Player, PuzzleHolder);
                    player.transform.position = new Vector3(i, j, -1f);
                }
                ++nodeNumber;
            }
        }
    }

    void InitializeFriend()
    {
        ActualFriend = Instantiate(Friend, PuzzleHolder);
        ActualFriend.transform.position = GetRandomPosition();
        FriendPosition = ActualFriend.transform.position;
    }

    void ChangeFriendPosition()
    {
        ActualFriend.transform.position = GetRandomPosition();
        FriendPosition = ActualFriend.transform.position;
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

        while (!walkableDictionary.ContainsKey(potentialVector))
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
