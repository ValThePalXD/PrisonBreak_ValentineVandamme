using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockController : MonoBehaviour
{

    public GameObject _box;
    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();


    }


    private void OnTriggerStay(Collider other)
    {
     
        if (other.name == "Player" && (Input.GetButtonDown("BButton")))
            other.gameObject.GetComponent<Animator>().SetTrigger("IsPushing");
        PushingBox();
    }

        private void PushingBox()
        {
            _box.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 12, ForceMode.Force);
        }
}

