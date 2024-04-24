using System.Collections;
using System.Collections.Generic;
using GLTFast;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] dontDestroyThese;
    public static DontDestroyObject Instance {get; private set;}
    private void Awake() {
        Instance = this;
    }
    public void InitializaDontDestroy()
    {
        foreach(GameObject go in dontDestroyThese)
        {
            if(go.tag == "Player")
            {
                go.transform.position = Vector3.zero;
            }
            DontDestroyOnLoad(go);
        }
    }

}
