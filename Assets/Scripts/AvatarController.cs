using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.Core;
using UnityEngine;
using UnityEngine.AI;

public class AvatarController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform followTransform;
    [SerializeField] Transform xrOrigin;
    [SerializeField] Animator AvatarAnimator;
    private NavMeshAgent navMeshAgent;
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
        if(navMeshAgent.enabled == false)return;
        navMeshAgent.SetDestination(followTransform.position);
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            transform.LookAt(xrOrigin);
            PlayWalkAnim(false);
        }
        else
        {
            PlayWalkAnim(true);
        }
    }
    public void PlayWalkAnim(bool flag)
    {
        AvatarAnimator.SetBool("walk",flag);
    }
    public void PlayTalkAnim(bool flag)
    {
        AvatarAnimator.SetBool("talk",flag);
    }
    public void SetNavMeshAgent(bool flag)
    {
        navMeshAgent.enabled = flag;
    }
    
}
