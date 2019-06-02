using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitingState : StateMachineBehaviour
{
    [SerializeField]
    private float waitingTime = 5.0f;

    private float timer = 0.0f;

    [SerializeField]
    private VoicePack voicePack;
    [SerializeField]
    private float voiceDelay;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        voicePack = animator.GetComponent<AIConfig>().voicePack;
        timer = 0.0f;
        animator.GetComponent<NavMeshAgent>().isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer < waitingTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            animator.SetBool("isPatrolling",true);
            animator.SetBool("isOnPatrolPoint",false);
        }
    }

}
