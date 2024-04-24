using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PanelDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas UIMessage;
    [SerializeField] Canvas QuestionCanvas;
    private XROrigin xrOrigin;
    private void Start() {
        xrOrigin = PlayerManager.Instance.GetComponent<XROrigin>();
         if(QuestionCanvas!=null)QuestionCanvas.gameObject.SetActive(false);
    }
    private void Update() {
        if(xrOrigin!=null)UIMessage.transform.LookAt(xrOrigin.transform);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<XROrigin>())
        {
            UIMessage.gameObject.SetActive(false);
            if(QuestionCanvas!=null)QuestionCanvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        UIMessage.gameObject.SetActive(true);
        if(QuestionCanvas!=null)QuestionCanvas.gameObject.SetActive(false);
    }
}
