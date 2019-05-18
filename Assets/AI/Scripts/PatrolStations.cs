using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStations : MonoBehaviour
{
    public List<Transform> stations;
    [SerializeField]
    private bool patrolling;
    [SerializeField]
    private Transform currentStation;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        currentStation = stations[0];
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (patrolling)
        {
            navMeshAgent.isStopped = true;
            SetNewDestinationIfNeeded();
            navMeshAgent.destination = currentStation.position;
            navMeshAgent.isStopped = false;
        }
    }

    public void StartPatrolling()
    {
        patrolling = true;
    }

    public void StopPatrolling()
    {
        patrolling = false;
    }

    private void SetNewDestinationIfNeeded()
    {
        if (Vector3.Distance(transform.position, currentStation.position) < 1.0f)
        {
            if (stations.IndexOf(currentStation) == stations.Count - 1)
            {
                currentStation = stations[0];
            }
            else
            {
                currentStation = stations[stations.IndexOf(currentStation) + 1];
            }
            animator.SetBool("isOnPatrolPoint",true);

        }
    }
}
