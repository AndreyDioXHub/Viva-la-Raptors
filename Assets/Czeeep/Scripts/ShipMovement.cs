using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean _rightGrip;
    [SerializeField]
    private SteamVR_Action_Boolean _leftGrip;

    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private Transform _playerShip;
    [SerializeField]
    private Transform _rightHand;
    [SerializeField]
    private Transform _leftHand;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _moveSpeed = 1;
    [SerializeField]
    private float _treshHold = 0.12f;
    
    [SerializeField]
    private GameObject _moveCube;
    [SerializeField]
    private GameObject _axiser;
    private Transform _rightMovePointStart;
    private Transform _rightMovePointCurrent;
    private Axiser _rightAxiser;

    [SerializeField]
    private float _axeSpeed = 10;
    private float _xcur;
    private float _xre;
    private float _ycur;
    private float _yre;
    private float _zcur;
    private float _zre;

    [SerializeField]
    private GameObject _rotCube;
    private Axiser _leftAxiser;
    [SerializeField]
    private float _catchSpeed = 10;
    [SerializeField]
    private Transform _leftMovePointStart;
    [SerializeField]
    private Transform _leftMovePointCurrent;
    // Start is called before the first frame update
    void Start()
    {
        //ShipController.onDirection += Movement;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SMove();
        SRotate();
    }

    private void SRotate()
    {
        LeftAxiserProces();
        /* float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
         float mouseZ = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;*/
        float mouseX = 0;
        float mouseY = 0;
        float mouseZ = 0;
        if (_leftAxiser != null)
        {
            mouseX = _leftAxiser.Axis.x * _rotationSpeed * Time.deltaTime;
            mouseY = _leftAxiser.Axis.y * _rotationSpeed * Time.deltaTime;
            //mouseZ = _leftAxiser.Axis.z * _rotationSpeed * Time.deltaTime;
        }
        
        transform.localEulerAngles += new Vector3(-mouseY, mouseX, mouseZ);
    }

    private void SMove()
    {
        RightAxiserProces();
        

        if (_rightAxiser != null)
        {
            _xcur = _rightAxiser.Axis.x;
            _ycur = _rightAxiser.Axis.y;
            _zcur = _rightAxiser.Axis.z;
        }

        if (_xcur >= 0 && _xcur != _xre)
        {
            _xre += _axeSpeed * Time.deltaTime;
            if (_xre > _xcur)
            {
                _xre = _xcur;
            }
        }
        else if (_xcur < 0 && _xcur != _xre)
        {
            _xre -= _axeSpeed * Time.deltaTime;
            if (_xre < _xcur)
            {
                _xre = _xcur;
            }
        }

        if (_ycur >= 0 && _ycur != _yre)
        {
            _yre += _axeSpeed * Time.deltaTime;
            if (_yre > _ycur)
            {
                _yre = _ycur;
            }
        }
        else if (_ycur < 0 && _ycur != _yre)
        {
            _yre -= _axeSpeed * Time.deltaTime;
            if (_yre < _ycur)
            {
                _yre = _ycur;
            }
        }

        if (_zcur >= 0 && _zcur != _zre)
        {
            _zre += _axeSpeed * Time.deltaTime;
            if (_zre > _zcur)
            {
                _zre = _zcur;
            }
        }
        else if (_zcur < 0 && _zcur != _zre)
        {
            _zre -= _axeSpeed * Time.deltaTime;
            if (_zre < _zcur)
            {
                _zre = _zcur;
            }
        }

        Vector3 move = transform.right * _xre + transform.up * _yre + transform.forward * _zre;
        _characterController.Move(move * _moveSpeed * Time.deltaTime);
    }

    private void LeftAxiserProces()
    {
        if (_leftGrip.lastState == true)
        {
            if (_leftMovePointStart == null && _leftMovePointCurrent == null)
            {
                GameObject lmps = Instantiate(_axiser, _playerShip);
                _leftAxiser = lmps.GetComponent<Axiser>();

                _leftMovePointStart = lmps.transform;
                _leftMovePointStart.position = _leftHand.position;

                GameObject lmpc = Instantiate(_moveCube, _playerShip);
                _leftMovePointCurrent = lmpc.transform;
                _leftMovePointCurrent.position = _leftHand.position;
                _leftAxiser.Hand = lmpc.transform;
            }
            else
            {                
                _leftMovePointCurrent.position = _leftHand.position;
            }

        }
        else
        {
            if (_leftMovePointStart != null)
            {
                Destroy(_leftMovePointStart.gameObject);
            }
            if (_leftMovePointCurrent != null)
            {
                Destroy(_leftMovePointCurrent.gameObject);
            }
            _leftMovePointStart = null;
            _leftMovePointCurrent = null;
            
        }
    }

    private void RightAxiserProces()
    {
        if (_rightGrip.lastState == true)
        {
            if (_rightMovePointStart == null && _rightMovePointCurrent == null)
            {
                GameObject rmps = Instantiate(_axiser, _playerShip);//GameObject.CreatePrimitive(PrimitiveType.Cube);
                _rightAxiser = rmps.GetComponent<Axiser>();

                _rightMovePointStart = rmps.transform;
                _rightMovePointStart.position = _rightHand.position;
                // _rightMovePointStart.eulerAngles = _rightHandPosition.eulerAngles;

                GameObject rmpc = Instantiate(_moveCube, _playerShip); //GameObject.CreatePrimitive(PrimitiveType.Cube);
                _rightMovePointCurrent = rmpc.transform;
                _rightMovePointCurrent.position = _rightHand.position;
                _rightAxiser.Hand = rmpc.transform;
                //_rightMovePointCurrent.eulerAngles = _rightHandPosition.eulerAngles;
            }
            else
            {
                //_rightMovePointStart.LookAt(_rightMovePointCurrent);
                _rightMovePointCurrent.position = _rightHand.position;
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
