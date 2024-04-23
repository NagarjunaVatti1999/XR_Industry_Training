using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform followTransform;
    [SerializeField] Transform xrOrigin;
    [SerializeField] Animator AvatarAnimator;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        AvatarAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartWalking();
        
    }
    void StartWalking()
    {
        navMeshAgent.SetDestination(followTransform.position);
        if(navMeshAgent.remainingDistance <= 0)
        {
            transform.LookAt(xrOrigin);
            AvatarAnimator.SetBool("walk",false);

        }
        else
        {
            AvatarAnimator.SetBool("walk",true);
        }
    }
}
