using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectState : MonoBehaviour
{
    // Start is called before the first frame update
    public Statements statements;
    void Start()
    {
        
    }

    public Statements GetObjectState()
    {
        return statements;
    }
    // Update is called once per frame

}
