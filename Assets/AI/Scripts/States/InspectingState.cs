using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InspectingState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NavMeshAgent>().speed = 1.5f;
        animator.GetComponent<NavMeshAgent>().angularSpeed = 240.0f;
        animator.GetComponent<NavMeshAgent>().isStopped = false;

        animator.GetComponent<Ears>().StartFollowingSound();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Ears>().StopFollowingSound();
    }

}
