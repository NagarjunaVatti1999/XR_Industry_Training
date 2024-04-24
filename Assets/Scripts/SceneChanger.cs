using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneChanger Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        
    }
    public void ChangeScene(int intIndex)
    {
        if(intIndex == SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(intIndex);
        }
        else{
            DontDestroyObject.Instance.InitializaDontDestroy();
            SceneManager.LoadScene(intIndex);
        }   
    }
    public void ExtiSScene(int intIndex)
    {
        SceneManager.LoadScene(intIndex);
    }
}
