using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InspectingState : StateMachineBehaviour
{
    [SerializeField]
    private VoicePack voicePack;
    [SerializeField]
    private float voiceDelay;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        voicePack = animator.GetComponent<AIConfig>().voicePack;
        animator.GetComponent<NavMeshAgent>().speed = 1.5f;
        animator.GetComponent<NavMeshAgent>().angularSpeed = 240.0f;
        animator.GetComponent<NavMeshAgent>().isStopped = false;

        animator.GetComponent<Ears>().StartFollowingSound();
        voiceDelay = Random.Range(5.0f,10.0f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        voiceDelay -= Time.deltaTime;
        if (voiceDelay <= 0)
        {
            voiceDelay = Random.Range(5.0f,10.0f);
            voicePack.PlayCasual();
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Ears>().StopFollowingSound();
    }

}
