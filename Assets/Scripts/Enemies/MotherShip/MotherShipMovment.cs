using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMovment : MonoBehaviour
{
    public Vector3 _rotationVector;
    public float _rotationSpeed;
    void Update()
    {
        transform.Rotate(_rotationVector * _rotationSpeed*Time.deltaTime);
    }
}
