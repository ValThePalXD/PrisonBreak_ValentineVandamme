using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    //toad camera

    //Camera move
    
    public Transform LookAt;
    public Transform CamTransForm;

    public Animator Animator;

    

    public bool CameraRotation= true;

    public Transform ClimbPos;
    public Transform PushPos;
    

    //max angle almost 90 but not 90 because then u cant turn left and right anymore
    private const float Y_ANGLE_MIN = 0.0f;    
    private const float Y_ANGLE_MAX=  89.0f;

    private float _distance = 5.0f;
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;


   

        




    void Start()
    {

        //camera rotation movement

       if (CameraRotation)
            MoveCameraStart();


       

    }


    void Update () {


        if (Animator.GetBool("IsClimbing"))
        {
           
            CameraRotation = false;
            CamTransForm.transform.forward = new Vector3(ClimbPos.transform.forward.x, ClimbPos.transform.forward.y, ClimbPos.transform.forward.z);
            CamTransForm.transform.position = new Vector3(ClimbPos.transform.position.x, ClimbPos.transform.position.y, ClimbPos.position.z);

        }

        if (Animator.GetBool("IsPushing"))
        {

            CameraRotation = false;
            CamTransForm.transform.forward = new Vector3(PushPos.transform.forward.x, PushPos.transform.forward.y, PushPos.transform.forward.z);
            CamTransForm.transform.position = new Vector3(PushPos.transform.position.x, PushPos.transform.position.y, PushPos.position.z);

        }

        if (Input.GetAxis("Horizontal")>0f|| Input.GetAxis("Vertical")>0f|| Input.GetAxis("HorizontalCam")>0f || Input.GetAxis("VerticalCam")>0f|| Input.GetAxis("Horizontal") < 0f || Input.GetAxis("Vertical") < 0f || Input.GetAxis("HorizontalCam") < 0f || Input.GetAxis("VerticalCam") < 0f)
        {
            

            CameraRotation = true;
        }

        //camera rotation movement
        if (CameraRotation)
        {
            MoveCameraUpdate();
        }

       
       

    }


    #region Start

    private void MoveCameraStart()
    {
        CamTransForm = transform;
       
    }

   

    #endregion Start

    #region Update

    private void MoveCameraUpdate()
    {
        _currentX -= Input.GetAxis("HorizontalCam");
        _currentY += Input.GetAxis("VerticalCam");



        _currentY = Mathf.Clamp(_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        Vector3 dir = new Vector3(0, 0, -_distance);
       
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
       


      

       
        CamTransForm.position = LookAt.position + rotation * dir;




        CamTransForm.LookAt(LookAt.position);


    }

 

    #endregion

    




}
