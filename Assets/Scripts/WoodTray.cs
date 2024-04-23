using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WoodTray : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] XRSocketInteractor[] socketInteractors;    
    private void Start() {

    }

    private void Update() {
        foreach(XRSocketInteractor SI in socketInteractors)
        {
            if(SI.hasSelection == false)
            {
                GetComponent<SetObjectState>().statements = Statements.IncompleteTray;
                return;
            }
        }
        GetComponent<SetObjectState>().statements = Statements.CompleteTray;
    }
}
