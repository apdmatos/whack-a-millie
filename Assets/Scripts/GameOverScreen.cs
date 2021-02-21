using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text scoreText;
    public Text levelText;

    void Start()
    {
        scoreText.text = "Your score: " + ScoreHolder.score;
        levelText.text = "Your highest level: " + ScoreHolder.level;
    }

    public void PlayAgain() {
        SceneManager.LoadScene("game");
    }
}
