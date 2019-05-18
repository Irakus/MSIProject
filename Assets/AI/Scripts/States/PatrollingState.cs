using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingState : StateMachineBehaviour
{
    private PatrolStations patrolStations;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NavMeshAgent>().speed = 1.0f;
        animator.GetComponent<NavMeshAgent>().angularSpeed = 120.0f;
        animator.GetComponent<NavMeshAgent>().isStopped = false;

        patrolStations = animator.gameObject.GetComponent<PatrolStations>();
        patrolStations.StartPatrolling();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrolStations.StopPatrolling();
        animator.SetBool("isPatrolling", false);
    }
}
