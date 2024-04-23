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

    [SerializeField] Button xrbutton;
    private float timer = 0f;

    private void Start() {
        xrbutton.gameObject.SetActive(false);
    }
    private void Update() {

        if(!isTalking)return;
        if(timer >= audioclip.length)
        {
            //isTalking = false;
            //transform.GetComponent<TriggerBox>().enabled = false;
            xrbutton.gameObject.SetActive(true);
        }
        timer += Time.deltaTime;
    
    }
    private void OnTriggerEnter(Collider other) {

        if(isTalking == false && other.gameObject.GetComponent<XROrigin>())
        {   
            //voiceHandler.AudioClip = audioclip; //only when triggered AudioClip is assigned
            timer = 0f;
            isTalking = true;
            PlayAudio();
        }
    }
    private void PlayAudio()
    {
        voiceHandler.PlayAudioClip(audioclip);
    }
    
}
