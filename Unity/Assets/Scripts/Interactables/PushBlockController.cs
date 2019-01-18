using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PushBlockController : MonoBehaviour
{

    [Header("Gameobject Parameters")]
    [SerializeField]
    private GameObject Box;


    void Start()
    {
   
#if DEBUG
        Assert.IsNotNull(Box, "Dependency Error: This component needs a GameObject to push.");
        
#endif
    }



    private void OnTriggerStay(Collider other)
    {

        if (other.name == "Player" && (Input.GetButtonDown("BButton")))
        {
            other.gameObject.GetComponent<Animator>().SetBool("IsPushing", true);
            PushingBox();
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {

            other.gameObject.GetComponent<Animator>().SetBool("IsPushing", false);
        }
    }





    private void PushingBox()
        {
            Box.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 12, ForceMode.Force);
        }



}


