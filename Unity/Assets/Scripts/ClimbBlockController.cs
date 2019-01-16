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
            other.gameObject.GetComponent<Animator>().SetTrigger("IsClimbing");
            other.gameObject.transform.forward = new Vector3(other.gameObject.transform.forward.x, this.gameObject.transform.forward.y, other.gameObject.transform.forward.z);
        
      
    }
}
