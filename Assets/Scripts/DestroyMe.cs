using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float destroyTime = .2f;

    void Start()
    {
        Destroy (gameObject, destroyTime);
    }
}
