using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HighScoreManager : ScriptableObject
{
    private int highScore;

    public int getScore()
    {
        return highScore;
    }

    public void setHighScore(int newScore)
    {
        highScore = newScore;
    }
}
