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
            if (other.gameObject.GetComponent<Animator>().GetBool("IsPushing"))
            {

                Debug.Log("oof");

                other.gameObject.transform.forward = new Vector3(Box.transform.forward.x, Box.gameObject.transform.forward.y, Box.transform.forward.z);
            }
        }
    }
   



    

    private void PushingBox()
        {
            Box.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 12, ForceMode.Force);
        }



}


