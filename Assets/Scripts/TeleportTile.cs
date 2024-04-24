using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportTile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;

    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        
        if(obj.tag == "woodtray")
        {
            if(obj.GetComponent<SetObjectState>().statements == Statements.CompleteTray)
            {
                canvas.gameObject.SetActive(true);
            }
            
        }
    }
}
