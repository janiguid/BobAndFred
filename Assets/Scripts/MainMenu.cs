using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private HighScoreManager highScore;
    public bool isStart;
    public GameObject highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        isStart = true;
        highScoreText.GetComponent<TextMesh>().text = highScore.getScore().ToString();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCursorRight();
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveCursorLeft();
            
        }

        if (Input.GetKeyDown(KeyCode.Return) && isStart)
        {
            SceneManager.LoadScene(0);
        }
    }

    void MoveCursorLeft()
    {
        transform.position = new Vector3(-5.21f, -3.42f, 0f);
        isStart = true;
    }

    void MoveCursorRight()
    {
        transform.position = new Vector3(0.55f, -3.42f, 0f);
        isStart = true;
    }
}
