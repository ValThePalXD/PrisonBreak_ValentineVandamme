using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToCrouch : MonoBehaviour {

    public Animator _anim;
    public float InputX;
    public float InputY;


	// Use this for initialization
	void Start () {

        //get the animator
        _anim = this.gameObject.GetComponent<Animator>();



	}
	
	// Update is called once per frame
	void Update () {

        InputY = Input.GetAxis("Vertical");
        InputX = Input.GetAxis("Horizontal");

        _anim.SetFloat("InputY", InputY);
        _anim.SetFloat("InputX", InputX);

		
	}
}
