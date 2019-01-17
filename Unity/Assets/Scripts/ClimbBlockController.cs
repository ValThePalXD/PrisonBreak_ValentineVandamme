using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBlockController : MonoBehaviour
{
    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && (Input.GetButtonDown("AButton")))
        {
            other.gameObject.GetComponent<Animator>().SetBool("IsClimbing", true);
            
        }
    }


 
}
