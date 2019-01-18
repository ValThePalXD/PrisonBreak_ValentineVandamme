using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CelDoorCloseScript : MonoBehaviour
{

    [Header("Movement Parameters")]
    [SerializeField]
    private Transform Door;

    [SerializeField]
    private Transform MoveTo;

    void Start()
    {
        
#if DEBUG
        Assert.IsNotNull(Door, "Dependency Error: This component needs a Transform to work on.");
        Assert.IsNotNull(MoveTo, "Dependency Error: This component needs a Transform to move to.");
       
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "push")
        {
            CelDoorClosing();
        }


    }

    private void CelDoorClosing()
    {
        Door.position = Vector3.Lerp(Door.transform.position, MoveTo.position, 0.5f);
    }
}
