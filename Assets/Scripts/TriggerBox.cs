using ReadyPlayerMe.Core;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlaying = false;
    [SerializeField] VoiceHandler voiceHandler;
    private float timer = 0f;

    private void Update() {
      
    
    }
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.GetComponent<XROrigin>())
        {   
            Debug.Log("Overlapped");
            AvatarAudio.Instance.PlayDialogue();
        }
    }
    
}
