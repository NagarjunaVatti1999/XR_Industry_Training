using System.Collections;
using ReadyPlayerMe.Core;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBox : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isTalking = false;
    [SerializeField] AudioClip audioclip;
    [SerializeField] VoiceHandler voiceHandler;

    [SerializeField] Canvas buttons;
    private float timer = 0f;

    private void Start() {
        buttons.gameObject.SetActive(false);
    }
    private void Update() {

    
    }
    private void OnTriggerEnter(Collider other) {

        if(isTalking == false && other.gameObject.GetComponent<XROrigin>())
        {   
            //voiceHandler.AudioClip = audioclip; //only when triggered AudioClip is assigned
            timer = 0f;
            isTalking = true;
            PlayAudio();
            Invoke(nameof(ActivateButton), audioclip.length);
        }
    }
    void ActivateButton()
    {
        buttons.gameObject.SetActive(true);
    }
    private void PlayAudio()
    {
        voiceHandler.PlayAudioClip(audioclip);
    }
    
}
