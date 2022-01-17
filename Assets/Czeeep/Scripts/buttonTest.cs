using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class buttonTest : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Vector2 _input;
    [SerializeField]
    private SteamVR_Action_Boolean _grip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_grip.lastState);
        //Debug.Log(_input.axis.x + ""+_input.axis.y);
    }
}
