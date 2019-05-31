using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eyes : MonoBehaviour
{
    private float lookRadius = 3.0f;
    private float darkViewDistance = 7.5f;
    private float semiLightViewDistance= 13.5f;
    private float lightViewDistance = 21.5f;

    public Transform eyes;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private float timeToChase = 0.0f;
    [SerializeField]
    private Transform target;

    private Transform player;


    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("PlayerHead").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInFront())
        {

            CheckIfSeePlayer();

            UpdateLocalChaseTime();

            UpdateAnimatorChaseTime();
        }

    }

    private void CheckIfSeePlayer()
    {
        RaycastHit hit;
        Physics.Raycast(eyes.position, player.position - eyes.position, out hit, lightViewDistance);
        DrawDebugRays();
        if (HitIsVisiblePlayer(hit))
        {
            UpdateChaseInfo(hit);
        }
    }

    private bool PlayerInFront()
    {
        Debug.Log("The angle between AI and player is " + Vector3.Angle(eyes.forward.normalized, (player.position - eyes.position).normalized));
        if (Vector3.Angle(eyes.forward.normalized, (player.position - eyes.position).normalized) <= 90.0f) return true;
        else return false;
    }
    private void DrawDebugRays()
    {
        Vector3 eyes1 = eyes.position;

        Vector3 eyes2 = eyes.position + new Vector3(0.0f, 0.1f, 0.0f);
        Vector3 eyes3 = eyes.position + new Vector3(0.0f, 0.2f, 0.0f);

        Debug.DrawRay(eyes1, (player.position - eyes1).normalized * lightViewDistance, Color.yellow);
        Debug.DrawRay(eyes2, ((player.position - eyes2).normalized * semiLightViewDistance), Color.green);
        Debug.DrawRay(eyes3, (player.position - eyes3).normalized * darkViewDistance, Color.red);
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
    
    private void UpdateChaseInfo(RaycastHit hit)
    {
        target = hit.transform;
        navMeshAgent.destination = target.position;
        this.timeToChase = 10.0f;
    }

    private bool HitIsVisiblePlayer(RaycastHit hit)
    {
        return hit.collider.CompareTag("Player") && CanSee(hit.transform.GetComponent<Visibility>());
    }

    private bool CanSee(Visibility target)
    {
        float distance = Vector3.Distance(transform.position,target.transform.position);
        switch (target.Get())
        {
            case 0:
                return distance <= darkViewDistance;
            case 1:
                return distance <= semiLightViewDistance;
            default:
                return distance <= lightViewDistance;
        }

    }
}
