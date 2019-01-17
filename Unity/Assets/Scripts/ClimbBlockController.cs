using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbBlockController : MonoBehaviour
{
 

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && (Input.GetButtonDown("AButton")))
        {
            other.gameObject.GetComponent<Animator>().SetBool("IsClimbing", true);
            
        }
    }


 
}
