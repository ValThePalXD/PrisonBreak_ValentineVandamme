using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockController : MonoBehaviour
{

    public GameObject _box;

   

    private void Start()
    {
       


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

                other.gameObject.transform.forward = new Vector3(_box.transform.forward.x, _box.gameObject.transform.forward.y, _box.transform.forward.z);
            }
        }
    }
   



    

    private void PushingBox()
        {
            _box.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 12, ForceMode.Force);
        }

}


