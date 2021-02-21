using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int score;
    public static int scoreToReach;

    void Start()
    {
    }

    public static void AddScore(int amount)
    {
        score += amount;
        UIManager.instance.UpdateScore();
    }

    public static int ReadScore()
    {
        return score;
    }

    public static void ResetScore() 
    {
        score = 0;
    }
}
