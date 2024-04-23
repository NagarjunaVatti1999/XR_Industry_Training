using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.Core;
using System.Threading;
using System;
using Unity.VisualScripting;

public class AvatarAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public static AvatarAudio Instance {get; private set;}
    [SerializeField] VoiceHandler voiceHandler;
    [SerializeField] SOAudios[] audioClips;
    [SerializeField] Animator avatarAnimator;

    AudioClip clip;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        
    }

    public void PlayMessage(GameObject go)
    {
        Statements curr_state = go.GetComponent<SetObjectState>().GetObjectState();
        //Debug.Log("Current State : "+curr_state);
        foreach(SOAudios audio in audioClips)
        {
            if(curr_state == Statements.None)return;
            if(audio.state == curr_state)
            {
                clip = audio.audioClip;
                voiceHandler.PlayAudioClip(clip);
                avatarAnimator.SetBool("talk", true); 
                Invoke(nameof(StopTalking), clip.length);
            }
        }

    }
    // Update is called once per frame
    private void StopTalking()
    {
        avatarAnimator.SetBool("talk", false);
    }
    void Update()
    {

    }
    
    
}
