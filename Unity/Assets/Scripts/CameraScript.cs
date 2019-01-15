using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    //toad camera

        //Camera move
    
    public Transform LookAt;
    public Transform CamTransForm;

  

    //max angle almost 90 but not 90 because then u cant turn left and right anymore
    private const float Y_ANGLE_MIN = 0.0f;    
    private const float Y_ANGLE_MAX=  89.0f;

    private float _distance = 10.0f;
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;


   

        




    void Start()
    {

        //camera rotation movement
        MoveCameraStart();

       

    }


    void Update () {


        //camera rotation movement
        MoveCameraUpdate();

       
       

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
