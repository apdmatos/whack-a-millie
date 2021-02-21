using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Level " + GameManager.level;
        this.gameObject.SetActive(true);
    }

    public void LevelAnimationDone()
    {
        this.gameObject.SetActive(false);
        UIManager.instance.LevelTextAnimationDone();
    }
}
