using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateExt;

public class ChasingState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    Vector3 chaseTarget;
    [SerializeField]
    private VoicePack voicePack;
    [SerializeField]
    private float voiceDelay;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        voicePack = animator.GetComponent<AIConfig>().voicePack;
        animator.GetComponent<NavMeshAgent>().speed = 3.0f;
        animator.GetComponent<NavMeshAgent>().angularSpeed = 360.0f;
        animator.GetComponent<NavMeshAgent>().acceleration = 10.0f;
        animator.GetComponent<NavMeshAgent>().isStopped = false;
        voicePack.PlaySpotted();
        voiceDelay = Random.Range(5.0f,10.0f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        voiceDelay -= Time.deltaTime;
        if (voiceDelay <= 0)
        {
            voiceDelay = Random.Range(5.0f, 10.0f);
            voicePack.PlayChasing();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPatrolling", true);
        voicePack.PlayLost();
    }

}
