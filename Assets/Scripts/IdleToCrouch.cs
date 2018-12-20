using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToCrouch : MonoBehaviour {

    public Animator Animator;
    public float InputX;
    public float InputY;


	// Use this for initialization
	void Start () {

        //get the animator
        Animator = this.gameObject.GetComponent<Animator>();



	}
	
	// Update is called once per frame
	void Update () {

        InputY = Input.GetAxis("Vertical");
        InputX = Input.GetAxis("Horizontal");

        Animator.SetFloat("InputY", InputY);
        Animator.SetFloat("InputX", InputX);

		
	}
}
