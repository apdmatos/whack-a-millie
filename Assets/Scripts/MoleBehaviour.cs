using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    Collider col;

    public int hitPointes = 1;

    public int score = 1;

    [HideInInspector]
    public GameObject myParent;

    [HideInInspector]
    public Animator anim;

    public GameObject popupText;
    public AudioClip sound;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    public void DestroyObj()
    {
        if(myParent != null) {
            myParent.GetComponent<HoleBehaviour>().hasMole = false;
        }
        
        Destroy (gameObject);
    }

    public void SwitchCollider(int num)
    {
        col.enabled = num == 0 ? false : true;
    }

    public void GotHit()
    {
        GameManager.instance.PlayClip(sound);
        hitPointes--;
        if (hitPointes > 0)
        {
            col.enabled = true;
        }
        else
        {
            ScoreManager.AddScore (score);

            GameObject pop = Instantiate(popupText) as GameObject;
            pop.transform.SetParent(UIManager.instance.transform, false);
            pop.transform.position =
                Camera.main.WorldToScreenPoint(transform.position);
            PopupText popText = pop.GetComponent<PopupText>();
            popText.ShowText (score);

            DestroyObj();
        }
    }
}
