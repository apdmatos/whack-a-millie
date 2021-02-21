using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float playTime = 60f;

    int seconds;

    int minutes;

    public static int level = 1;
    public static bool gameInPlay = false;

    [HideInInspector] public bool countDownDone;

    int baseScore = 100;

    int scoreToReach;
    static bool hasLost;

    private AudioSource audioData;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(hasLost) 
        {
            hasLost = false;
            ScoreManager.ResetScore();
            level = 1;
        }

        scoreToReach = level * baseScore;
        ScoreManager.scoreToReach = scoreToReach;
        UIManager.instance.UpdateScore();

        audioData = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip sound) {
        audioData.PlayOneShot(sound, 0.7f);
    }

    void Update()
    {
        if (countDownDone)
        {
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }

            if (playTime > 0)
            {
                playTime -= Time.deltaTime;
                seconds = (int) playTime % 60;
                minutes = (int) playTime / 60 % 60;
                UIManager.instance.UpdateTime (minutes, seconds);
            }
            CheckForWin();
        }
    }

    void CheckForWin()
    {
        if (ScoreManager.ReadScore() >= scoreToReach)
        {
            level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if (playTime <= 0)
            {
                hasLost = true;
                ScoreHolder.score = ScoreManager.ReadScore();
                ScoreHolder.level = level;
                SceneManager.LoadScene("gameover");
            }
        }
    }
}
