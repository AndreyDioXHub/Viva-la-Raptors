using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShipController : MonoBehaviour
{
    public static Action<Vector3, Vector3> onDirection = delegate{};
    [SerializeField]
    private Transform _ship;
    [SerializeField]
    private SteamVR_Action_Vector2 _joyStickInput;
    [SerializeField]
    private SteamVR_Action_Boolean _grip;
    [SerializeField]
    private Transform _rightHandPosition;
    [SerializeField]
    private Transform _StartPoint;
    [SerializeField]
    private Transform _rightMovePointStart;
    [SerializeField]
    private Transform _rightMovePointCurrent;
    [SerializeField]
    private GameObject _moveCube;
    [SerializeField]
    private GameObject _axiser;
    private Axiser _rightAxiser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_grip.lastState == true)
        {
            if(_rightMovePointStart == null && _rightMovePointCurrent == null)
            {
                GameObject rmps = Instantiate(_axiser, _ship);//GameObject.CreatePrimitive(PrimitiveType.Cube);
                _rightAxiser = rmps.GetComponent<Axiser>();
                
                _rightMovePointStart = rmps.transform;
                _rightMovePointStart.position = _rightHandPosition.position;
               // _rightMovePointStart.eulerAngles = _rightHandPosition.eulerAngles;

                GameObject rmpc = Instantiate(_moveCube, _ship); //GameObject.CreatePrimitive(PrimitiveType.Cube);
                _rightMovePointCurrent = rmpc.transform;
                _rightMovePointCurrent.position = _rightHandPosition.position;
                _rightAxiser.Hand = rmpc.transform;
                //_rightMovePointCurrent.eulerAngles = _rightHandPosition.eulerAngles;
            }
            else
            {
                //_rightMovePointStart.LookAt(_rightMovePointCurrent);
                _rightMovePointCurrent.position = _rightHandPosition.position;
                onDirection?.Invoke(_rightMovePointStart.localPosition, _rightMovePointCurrent.localPosition);
            }
            
        }
        else
        {
            if (_rightMovePointStart != null)
            {
                Destroy(_rightMovePointStart.gameObject);
            }
            if (_rightMovePointCurrent != null)
            {
                Destroy(_rightMovePointCurrent.gameObject);
            }  
            _rightMovePointStart = null;
            _rightMovePointCurrent = null;
        }
    }
}

