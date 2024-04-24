using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SceneIntroTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Start() {
        navMeshAgent.enabled = false;
    }
    private void OnTriggerEnter(Collider other) {
        navMeshAgent.enabled = true;
    }
}
