using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PressingButtonScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && (Input.GetButtonDown("YButton")))
        {
            other.gameObject.GetComponent<Animator>().SetBool("IsPressing", true);

        }
    }


   


}
