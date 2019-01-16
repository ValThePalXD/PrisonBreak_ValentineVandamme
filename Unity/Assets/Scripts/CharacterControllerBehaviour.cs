using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerBehaviour : MonoBehaviour
{
    [Header("Animation Parameters")]
    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private float InputX;

    [SerializeField]
    private float InputY;


    [Header("Climbing Parameters")]

    [SerializeField]
    private GameObject EndPos;

    [Header("Locomotion Parameters")]
    [SerializeField]
    private float _mass = 66.7f; // the average weight of an adult woman in Belgium is 66.7 kg

    [SerializeField]
    private float _acceleration = 3; // [m/s^2]

    [SerializeField]
    private float _dragOnGround = 1; // []

    [SerializeField]
    private float _maxWalkingSpeed = (5.0f * 1000) / (60 * 60); // setting default forwardspeed
    private float _maxForwardSpeed = (5.0f * 1000) / (60 * 60); // the average walking speed of a human is about 5 km/h
    private float _maxBackwardSpeed = ((5.0f/1.3f) * 1000) / (60 * 60); //the average backwards walking speed is about 1.1 times slower than forward speed, after tweaking I found 1.3 times to make the animation smoother and more realistic

   

    [Header("Dependencies")]
    [SerializeField, Tooltip("What should determine the absolute forward when a player presses forward.")]
    private Transform _absoluteForward;

    private CharacterController _characterController;

    private Vector3 _velocity = Vector3.zero;

    private Vector3 _movement;
    private bool _jump;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _anim = this.gameObject.GetComponent<Animator>();
#if DEBUG
        Assert.IsNotNull(_anim, "Dependency Error: This component needs an Animator  to work.");
        Assert.IsNotNull(_characterController, "Dependency Error: This component needs a CharacterController to work.");
        Assert.IsNotNull(_absoluteForward, "Dependency Error: Set the Absolute Forward field.");
#endif
    }

    void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        

        InputY = Input.GetAxis("Vertical");
        InputX = Input.GetAxis("Horizontal");

        _anim.SetFloat("InputY", InputY);
        _anim.SetFloat("InputX", InputX);

        if (InputY > -0.3f && InputY < 0.3f)
        {

            InputY = 0;

        }
        if (InputX > -0.3f && InputX < 0.3f)
        {

            InputX = 0;

        }

        if (InputY < 0f)
        {

            _maxWalkingSpeed = _maxBackwardSpeed;

        }
        else
        {

            _maxWalkingSpeed = _maxForwardSpeed;

        }
    }

    void FixedUpdate()
    {
      
        ApplyGround();
        ApplyGravity();
        ApplyMovement();
        ApplyGroundDrag();
        AnimatorBooleans();

        LimitMaximumRunningSpeed();

        _characterController.Move(_velocity * Time.deltaTime);

       
        gameObject.transform.forward = new Vector3(_absoluteForward.transform.forward.x, gameObject.transform.forward.y, _absoluteForward.transform.forward.z);



    }

    private void AnimatorBooleans()
    {
        _anim.SetBool("IsGrounded", _characterController.isGrounded);
       
       
    }

    private void ApplyGround()
    {
        if (_characterController.isGrounded)
        {
          

            _velocity -= Vector3.Project(_velocity, Physics.gravity.normalized);
        }
    }

    private void ApplyGravity()
    {
        
        _velocity += Physics.gravity * Time.deltaTime; // g[m/s^2] * t[s]
       
    }

    private void ApplyMovement()
    {
        if (_characterController.isGrounded)
        {
            Vector3 xzAbsoluteForward = Vector3.Scale(_absoluteForward.forward, new Vector3(1, 0, 1));

            Quaternion forwardRotation =
                Quaternion.LookRotation(xzAbsoluteForward);

            Vector3 relativeMovement = forwardRotation * _movement;

            _velocity += relativeMovement * _mass * _acceleration * Time.deltaTime; // F(= m.a) [m/s^2] * t [s]
        }
    }

    private void ApplyGroundDrag()
    {
        if (_characterController.isGrounded)
        {
            _velocity = _velocity * (1 - Time.deltaTime * _dragOnGround);
        }
    }





    private void LimitMaximumRunningSpeed()
    {
        Vector3 yVelocity = Vector3.Scale(_velocity, new Vector3(0, 1, 0));

        Vector3 xzVelocity = Vector3.Scale(_velocity, new Vector3(1, 0, 1));
        Vector3 clampedXzVelocity = Vector3.ClampMagnitude(xzVelocity, _maxWalkingSpeed);

        _velocity = yVelocity + clampedXzVelocity;
    }


    #region ClimbingAnimatiom

    public void FinishClimb()
    {
       
        gameObject.transform.position = EndPos.transform.position;
        _absoluteForward.transform.forward = new Vector3 (EndPos.transform.forward.x, EndPos.transform.forward.y, EndPos.transform.forward.z);
        Debug.Log("qrjwjegkltrkbjhtrbbehrbjghrejhgv");
    }

    #endregion
}
