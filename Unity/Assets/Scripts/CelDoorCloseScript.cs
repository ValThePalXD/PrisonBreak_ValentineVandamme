using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelDoorCloseScript : MonoBehaviour
{
    public GameObject Door;
    public Transform MoveTo;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "push")
        {
            CelDoorClosing();
        }


    }

    private void CelDoorClosing()
    {
        Door.transform.position = Vector3.Lerp(Door.transform.position, MoveTo.position, 0.5f);
    }
}
