using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject fx_particles;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Mole")
                {

                    Instantiate(fx_particles, hit.point, Quaternion.identity);

                    MoleBehaviour mole = hit.collider.gameObject.GetComponent<MoleBehaviour>();
                    mole.SwitchCollider(0);
                    mole.anim.SetTrigger("hit");
                }
            }
        }
    }
}
