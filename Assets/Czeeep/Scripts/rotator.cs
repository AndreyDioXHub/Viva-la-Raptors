using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField]
    private Transform _rightHand;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _rotTreshHold = 25f;
    [SerializeField]
    private Vector3 _originRot;
    private Vector3 _rotDir;
    private float _angleX;
    private float _angleY;
    private float _angleZ;
    private float _angleXNorm;
    private float _angleYNorm;
    private float _angleZNorm;
    // Start is called before the first frame update
    void Start()
    {
        _originRot = _rightHand.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        ShipRotation();
    }

    private void ShipRotation()
    {
        _angleX = _rightHand.localEulerAngles.x - _originRot.x;
        if (_angleX > 180)
        {
            _angleX = _angleX - 360;
        }

        if (_angleX * _angleX < _rotTreshHold)
        {
            _angleXNorm = 0;
        }
        else
        {
            _angleXNorm = (_angleX > 0) ? 1 : -1;
        }

        _angleY = _rightHand.localEulerAngles.y - _originRot.y;
        if (_angleY > 180)
        {
            _angleY = _angleY - 360;
        }

        if (_angleY * _angleY < _rotTreshHold)
        {
            _angleYNorm = 0;
        }
        else
        {
            _angleYNorm = (_angleY > 0) ? 1 : -1;
        }

        _angleZ = _rightHand.localEulerAngles.z - _originRot.z;
        if (_angleZ > 180)
        {
            _angleZ = _angleZ - 360;
        }

        if (_angleZ * _angleZ < _rotTreshHold)
        {
            _angleZNorm = 0;
        }
        else
        {
            _angleZNorm = (_angleZ > 0) ? 1 : -1;
        }

        _rotDir = new Vector3(_angleXNorm, _angleYNorm, _angleZNorm);

        transform.eulerAngles += _rotDir * _rotationSpeed * Time.deltaTime;
    }
}
