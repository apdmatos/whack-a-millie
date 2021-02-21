using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehaviour : MonoBehaviour
{
    public GameObject[] moles;

    public bool hasMole;

    void Start()
    {
        if (!hasMole)
        {
            Invoke("Spawn", Random.Range(0f, 7f));
        }
    }

    void Spawn()
    {
        if (!hasMole && GameManager.instance.countDownDone)
        {
            int idx = CalculateRarity();
            GameObject mole =
                Instantiate(moles[idx],
                this.transform.position,
                Quaternion.identity) as
                GameObject;
            MoleBehaviour moleB = mole.GetComponent<MoleBehaviour>();
            moleB.myParent = this.gameObject;
            moleB.score = moleB.score * GameManager.level;
            hasMole = true;
        }
        Invoke("Spawn", Random.Range(0f, 7f));
    }

    int CalculateRarity()
    {
        int num = Random.Range(1, 101);
        if (num <= 5)
        {
            return 3;
        }
        else if (num <= 30)
        {
            return 2;
        }
        else if (num <= 50)
        {
            return 1;
        }

        return 0;
    }
}
