using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private XRSocketInteractor socketInteractor;
    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame

    public void OnObjectEntered(SelectEnterEventArgs arg0)
    {
        Debug.Log("Entered Socket");
        IXRSelectInteractable obj = socketInteractor.GetOldestInteractableSelected();
        if(obj!=null)
        {
            AvatarAudio.Instance.PlayMessage(obj.transform.gameObject);
        }
        
    }

    void Update()
    {
        
         
    }
}
