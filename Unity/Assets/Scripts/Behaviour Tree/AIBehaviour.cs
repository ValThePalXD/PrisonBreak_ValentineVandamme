
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIBehaviour : MonoBehaviour
{

    private INode _startNode;
    private NavMeshAgent _agent;
    private Animator animator;

    private float _maxRoamDistance = 10.0f;

    //met velocity


    // Start is called before the first frame update
    void Start()
    {
        


        animator = gameObject.GetComponent<Animator>();

        _agent = gameObject.GetComponent<NavMeshAgent>();

        _startNode = new SelectorNode
        (
            new SequenceNode
            (
                new ConditionNode(IsTrapped),
                new ActionNode(PlayAngryAnimation)
            ),
            new SequenceNode
            (
                new ConditionNode(Free),
                new ActionNode(LookingFor)


                ),
             new SequenceNode
            (
                new ConditionNode(Found),
                new ActionNode(AimAt)


             ));

        StartCoroutine(RunTree());





    }

    IEnumerator RunTree()
    {
        while(Application.isPlaying)
        {
            yield return _startNode.Tick();

        }



    }


    bool IsTrapped()
    {
        return false;
    }


    bool Free()
    {
        return true;
    }



    bool Found()
    {
        return false;
    }


    IEnumerator<NodeResult> PlayAngryAnimation()
    {

        //play the animation


        yield return NodeResult.Succes;
    }


    IEnumerator<NodeResult> LookingFor()
    {

        //walk around
        AIAnimation();

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            float newTarget = Random.Range(0, 100);
            if (newTarget >= 99)
            {
                Vector3 newPosition = transform.position + Random.insideUnitSphere * _maxRoamDistance;
                NavMeshHit hit;
                NavMesh.SamplePosition(newPosition, out hit, Random.Range(0, _maxRoamDistance), 1);

                _agent.SetDestination(hit.position);
            }
        }



        yield return NodeResult.Succes;
    }


    IEnumerator<NodeResult> AimAt()
    {

        //look at player


        yield return NodeResult.Succes;
    }


   



    private void AIAnimation()
    {
        animator.SetFloat("AIVertical", _agent.velocity.x);
        animator.SetFloat("AIHorizontal", _agent.velocity.z);

    }
}
