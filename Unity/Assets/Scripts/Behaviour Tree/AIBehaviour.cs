
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIBehaviour : MonoBehaviour
{

    private INode _startNode;
    private NavMeshAgent _agent;
    private Animator animator;

    private bool FoundPlayer = false;
    private bool IsTrappedByPlayer = false;

    private readonly float _maxRoamDistance = 10.0f;

    


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
                new ActionNode(Aim)


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

    private void Update()
    {

        if (animator.GetBool("Found"))
        {
            
            FoundPlayer = true;
        }

        if (animator.GetBool("IsTrapped"))
        {
            IsTrappedByPlayer = true;
        }


    }

    bool IsTrapped()
    {
        return IsTrappedByPlayer;
    }


    bool Free()
    {
        return true;
    }



    bool Found()
    {
      
        return FoundPlayer;
    }

    IEnumerator<NodeResult> PlayAngryAnimation()
    {

      
        _agent.velocity = Vector3.zero;
        _agent.enabled = false;


        yield return NodeResult.Succes;
    }


    IEnumerator<NodeResult> LookingFor()
    {

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


    IEnumerator<NodeResult> Aim()
    {

      
        _agent.velocity = Vector3.zero;
        _agent.enabled = false;

        yield return NodeResult.Succes;
    }


   



    private void AIAnimation()
    {
        animator.SetFloat("AIVertical", _agent.velocity.x);
        animator.SetFloat("AIHorizontal", _agent.velocity.z);

    }
}
