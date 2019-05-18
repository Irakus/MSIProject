using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookForIntruders : MonoBehaviour
{
    public float lookRadius = 2.0f;
    private float darkViewDistance = 6.0f;
    private float semiLightViewDistance= 12.0f;
    private float lightViewDistance = 20.0f;

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
        RaycastHit[] hits = Physics.SphereCastAll(eyes.position, lookRadius, transform.forward, lightViewDistance);
        Debug.DrawRay(eyes.position, transform.forward * lightViewDistance, Color.red);
        Debug.DrawRay(eyes.position + new Vector3(0.0f,0.1f,0.0f), transform.forward * semiLightViewDistance, Color.green);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.2f, 0.0f), transform.forward * darkViewDistance, Color.blue);
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
                if (hit.collider.CompareTag("Player") && CanSee(hit.transform.GetComponent<Visibility>()))
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

    private bool CanSee(Visibility target)
    {
        float distance = Vector3.Distance(transform.position,target.transform.position);
        switch (target.Get())
        {
            case 0:
                return distance <= darkViewDistance;
                break;
            case 1:
                return distance <= semiLightViewDistance;
                break;
            default:
                return distance <= lightViewDistance;
                break;
        }

    }
}
