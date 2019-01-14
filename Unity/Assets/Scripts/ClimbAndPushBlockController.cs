using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class ClimbOnBlock : MonoBehaviour
{
    //public GameObject Player;
    public Animator ClimbingAnimation;

    private void Start()
    {
        ClimbingAnimation = GetComponent<Animator>();


    }



    //void OnTriggerStay()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        ClimbingAnimation.Play ("Climbing");
    //        Debug.Log("E pressed");
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && (Input.GetKeyDown(KeyCode.E)))
            other.gameObject.GetComponent<Animator>().SetTrigger("IsClimbing");


    
    }
   




    }
