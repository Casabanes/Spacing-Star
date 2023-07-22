using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldRotation : MonoBehaviour
{
    [SerializeField]
    private float _speedRotation;
    private const int _constZero = 0;
    void Update()
    {
        transform.Rotate(new Vector3(_constZero, _constZero, _speedRotation)*Time.deltaTime);   
    }
}
