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
    [SerializeField] AvatarController avatarController;

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
        foreach(SOAudios audio in audioClips)
        {
            if(curr_state == Statements.None)return;
            if(audio.state == curr_state)
            {
                clip = audio.audioClip;
                PlayAudioMessage(clip);
                avatarController.PlayTalkAnim(true);

                avatarController.SetNavMeshAgent(false);

                Invoke(nameof(StopTalking), clip.length);
            }
        }

    }
    // Update is called once per frame
    private void StopTalking()
    {
        avatarController.PlayTalkAnim(false);
        avatarController.SetNavMeshAgent(true);
    }
    public void PlayAudioMessage(AudioClip clip)
    {
        voiceHandler.PlayAudioClip(clip);
    }
}
