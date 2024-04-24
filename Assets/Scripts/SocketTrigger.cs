using System;
using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe.Core;
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
        IXRSelectInteractable obj = socketInteractor.GetOldestInteractableSelected();
        if(obj!=null)
        {
            AvatarAudio.Instance.PlayMessage(obj.transform.gameObject);
            AddObjectScore(obj);
            obj.transform.GetComponent<SetObjectState>().statements = Statements.ObjectAdded; //state changed to object added
        }
    }

    private void AddObjectScore(IXRSelectInteractable obj)
    {
        if(obj.transform.GetComponent<SetObjectState>().statements != Statements.ObjectAdded)
        {
            ScoreManager.Instance.AddScore();
        }
    }
    void Update()
    {
        
         
    }
}
