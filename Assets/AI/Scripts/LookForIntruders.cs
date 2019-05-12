using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookForIntruders : MonoBehaviour
{
    public float lookRadius = 5.0f;
    public float lookDistance = 10.0f;
    public Transform eyes;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private float timeToChase = 0.0f;
    [SerializeField]
    private Transform target;


    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var hits = TryToFindPlayer();

        CheckIfSeenPlayer(hits);
        
        UpdateLocalChaseTime();

        UpdateAnimatorChaseTime();
    }

    private RaycastHit[] TryToFindPlayer()
    {
        RaycastHit[] hits = Physics.SphereCastAll(eyes.position, lookRadius, transform.forward, lookDistance);
        Debug.DrawRay(eyes.position, transform.forward * lookDistance, Color.red);
        return hits;
    }

    private void UpdateAnimatorChaseTime()
    {
        animator.SetFloat("chasingTimeRemaining", timeToChase);
    }

    private void UpdateLocalChaseTime()
    {
        if (timeToChase > 0.0f)
        {
            timeToChase -= Time.deltaTime;
        }
    }

    private void CheckIfSeenPlayer(RaycastHit[] hits)
    {
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    navMeshAgent.isStopped = true;
                    target = hit.transform;
                    navMeshAgent.destination = target.position;
                    navMeshAgent.isStopped = false;
                    this.timeToChase = 10.0f;
                    break;
                }
            }
        }
    }
}
