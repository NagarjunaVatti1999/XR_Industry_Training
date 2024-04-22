using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HandAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputActionReference gripActionReference;
    [SerializeField] InputActionReference triggerActionReference;
    [SerializeField] Animator handAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float grip = gripActionReference.action.ReadValue<float>();    
        handAnim.SetFloat("grip", grip);

        float trigger = triggerActionReference.action.ReadValue<float>();
        handAnim.SetFloat("trigger", trigger);
    }
}
