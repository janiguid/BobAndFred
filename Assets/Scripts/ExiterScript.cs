using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExiterScript : MonoBehaviour
{
    private HighScoreManager highScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PuzzleInitializer.walkableDictionary.Clear();
            SceneManager.LoadScene(1);

        }
    }

    public static void EndGame()
    {

         PuzzleInitializer.walkableDictionary.Clear();
         SceneManager.LoadScene(1);

    }
}
