using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axiser : MonoBehaviour
{
    [SerializeField]
    private Transform _center;
    public Transform Hand;
    [SerializeField]
    private float _lenght = 0.1f;
    public Vector3 Axis = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = (Hand.localPosition.x - _center.localPosition.x) / _lenght;
        float y = (Hand.localPosition.y - _center.localPosition.y) / _lenght;
        float z = (Hand.localPosition.z - _center.localPosition.z) / _lenght;
        Axis = new Vector3(x, y, z);
    }
}
