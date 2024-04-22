using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.Core;

public class AvatarAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public static AvatarAudio Instance {get; private set;}
    [SerializeField] VoiceHandler voiceHandler;
    [SerializeField] AudioClip audioClip;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        voiceHandler.AudioClip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDialogue()
    {
        voiceHandler.PlayCurrentAudioClip();
    }
    
}
