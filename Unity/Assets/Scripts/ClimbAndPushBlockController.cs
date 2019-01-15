using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbAndPushBlockController : MonoBehaviour
{
    public Animator ClimbingAnimation;

    private void Start()
    {
        ClimbingAnimation = GetComponent<Animator>();


    }



    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && (Input.GetButtonDown("AButton")))
            other.gameObject.GetComponent<Animator>().SetTrigger("IsClimbing");


        if (other.name == "Player" && (Input.GetKeyDown(KeyCode.Q)))
            other.gameObject.GetComponent<Animator>().SetTrigger("IsPushing");

    }
}
