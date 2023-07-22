using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotsFather : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy;
    private float _actualTime;
    void Update()
    {
        _actualTime += Time.deltaTime;
        if (_timeToDestroy <= _actualTime)
        {
            Destroy(gameObject);
        }
    }
}
