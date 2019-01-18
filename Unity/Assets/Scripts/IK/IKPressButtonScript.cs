using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class IKPressButtonScript : MonoBehaviour
{
    [Header("IK Parameters")]
    [SerializeField]
    private Transform _myPointFinger;

    [SerializeField]
    private Transform _button;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float iKWeight =0;


    [Header("Door Parameters")]
    [SerializeField]
    private GameObject _door;

    [SerializeField]
    private Transform _moveTo;


    void Start()
    {
        
        _animator = this.gameObject.GetComponent<Animator>();
#if DEBUG
        Assert.IsNotNull(_animator, "Dependency Error: This component needs an Animator  to work.");
        Assert.IsNotNull(_myPointFinger, "Dependency Error: This component needs a finger Transform to work with.");
        Assert.IsNotNull(_button, "Dependency Error: This component needs a button to go to.");
#endif
    }

    private void Update()
    {
        if (_animator.GetBool("IsPressing"))
        {
           
            iKWeight = 0.5f;
        }
    }


    private void OnAnimatorIK()
    {
        _animator.SetIKPosition(AvatarIKGoal.RightHand, new Vector3(_button.position.x, _button.position.y, _button.position.z));
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, iKWeight);
    }

    public void ButtonPressed()
    {

        iKWeight = 0.0f;
        _door.transform.position = Vector3.Lerp(_door.transform.position,_moveTo.position,50f);

        
    }

    


}
