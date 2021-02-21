using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;
    public Text timeText;
    public Text levelText;
    public GameObject countDown;
    public GameObject gameImage;
    public GameObject playButton;

    void Awake()
    {
        instance = this;
        UpdateTime(1, 0);

        if(GameManager.gameInPlay) 
        {
            Play();
        } else 
        {
            gameImage.SetActive(true);
            playButton.SetActive(true);
        }
    }

    public void UpdateTime(int min, int sec)
    {
        timeText.text = min.ToString("D2") + ":" + sec.ToString("D2");
    }

    public void UpdateScore()
    {
        scoreText.text = "Score " + ScoreManager.ReadScore() + "/" + ScoreManager.scoreToReach;
    }

    public void LevelTextAnimationDone() 
    {
        countDown.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
    }

    public void Play() 
    {
        GameManager.gameInPlay = true;
        gameImage.SetActive(false);
        playButton.SetActive(false);

        levelText.gameObject.SetActive(true);
    }
}
