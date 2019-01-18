using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraScript : MonoBehaviour {

    [Header("Camera Parameters")]
    [SerializeField]
    private Transform LookAt;

    [SerializeField]
    private Transform CamTransForm;

    [SerializeField]
    private bool CameraRotation= true;

    [Header("Animation Parameters")]
    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private Transform ClimbPos;

   


    

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
#if DEBUG
        Assert.IsNotNull(Animator, "Dependency Error: This component needs an Animator  to work.");
        Assert.IsNotNull(LookAt, "Dependency Error: This component needs a transform to look at.");
#endif



    }


    void Update () {


        if (Animator.GetBool("IsClimbing"))
        {
           
            CameraRotation = false;
            ChangeClimbPos();

           

        }

        

        if (Input.GetAxis("Horizontal")>0f|| 
            Input.GetAxis("Vertical")>0f|| 
            Input.GetAxis("HorizontalCam")>0f || 
            Input.GetAxis("VerticalCam")>0f|| 
            Input.GetAxis("Horizontal") < 0f || 
            Input.GetAxis("Vertical") < 0f || 
            Input.GetAxis("HorizontalCam") < 0f || 
            Input.GetAxis("VerticalCam") < 0f)
        {
            

            CameraRotation = true;
        }

        
        if (CameraRotation)
        {
            MoveCameraUpdate();
        }

       
       

    }
    #region PositionChangesAnimation


   
    private void ChangeClimbPos()
    {
        CamTransForm.transform.forward = new Vector3(ClimbPos.transform.forward.x, ClimbPos.transform.forward.y, ClimbPos.transform.forward.z);
        CamTransForm.transform.position = new Vector3(ClimbPos.transform.position.x, ClimbPos.transform.position.y, ClimbPos.position.z);
    }

    #endregion


    #region Camera

    private void MoveCameraStart()
    {
        CamTransForm = transform;
       
    }

   
    

    

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
