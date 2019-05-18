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
            ChangeCurrentStationIfNeeded();
            navMeshAgent.destination = currentStation.position;
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

    private void ChangeCurrentStationIfNeeded()
    {
        if (CloseEnough())
        {
            if (IsOnLastStation())
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

    private bool IsOnLastStation()
    {
        return stations.IndexOf(currentStation) == stations.Count - 1;
    }

    private bool CloseEnough()
    {
        return Vector3.Distance(transform.position, currentStation.position) < 1.0f;
    }
}
