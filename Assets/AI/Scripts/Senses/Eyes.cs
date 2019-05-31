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


    void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange())
        {

            CheckIfSeePlayer();

            UpdateLocalChaseTime();

            UpdateAnimatorChaseTime();
        }

    }

    private void CheckIfSeePlayer()
    {
        RaycastHit hit;
        Physics.Raycast(eyes.position, player.position,out hit, lightViewDistance);
        if (hit.collider.CompareTag("Player") && CanSee(hit.transform.GetComponent<Visibility>()))
        {
            UpdateChaseInfo(hit);
        }
    }

    private bool PlayerInRange()
    {
        Debug.Log("The angle between AI and player is " + Vector3.Angle(eyes.forward.normalized, (player.position - eyes.position).normalized));
        if (Vector3.Distance(eyes.position, player.position) <= lightViewDistance
            && Vector3.Angle(eyes.forward.normalized, (player.position - eyes.position).normalized )>= -90.0f
            && Vector3.Angle(eyes.forward.normalized, (player.position - eyes.position).normalized) <= 90.0f) return true;
        else return false;
    }

    private RaycastHit[] TryToFindPlayer()
    {
        RaycastHit[] hits = Physics.SphereCastAll(eyes.position, lookRadius, transform.forward, lightViewDistance);
        DrawDebugRays();
        return hits;
    }

    private void DrawDebugRays()
    {
        Debug.DrawRay(eyes.position - eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * lightViewDistance, Color.red);
        Debug.DrawRay(eyes.position - eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * lightViewDistance, Color.red);
        Debug.DrawRay(eyes.position + eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * lightViewDistance, Color.red);
        Debug.DrawRay(eyes.position + eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * lightViewDistance, Color.red);

        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.1f, 0.0f) - eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * semiLightViewDistance,
            Color.green);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.1f, 0.0f) - eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * semiLightViewDistance,
            Color.green);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.1f, 0.0f) + eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * semiLightViewDistance,
            Color.green);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.1f, 0.0f) + eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * semiLightViewDistance,
            Color.green);

        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.2f, 0.0f) - eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * darkViewDistance, Color.blue);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.2f, 0.0f) - eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * darkViewDistance, Color.blue);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.2f, 0.0f) + eyes.right.normalized * lookRadius / 2 - eyes.up.normalized * lookRadius / 2, transform.forward * darkViewDistance, Color.blue);
        Debug.DrawRay(eyes.position + new Vector3(0.0f, 0.2f, 0.0f) + eyes.right.normalized * lookRadius / 2 + eyes.up.normalized * lookRadius / 2, transform.forward * darkViewDistance, Color.blue);

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
                if (SpottedPlayer(hit)) break;
            }
        }
    }

    private bool SpottedPlayer(RaycastHit hit)
    {
        if (HitIsVisiblePlayer(hit))
        {
            UpdateChaseInfo(hit);
            return true;
        }

        return false;
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
