using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsWorldSet : MonoBehaviour
{
    public Transform[] _positions;
    public Vector3[] _realPositions;
    [SerializeField]
    AlienEnemy _alienEnemy;
    const int _constZero = 0;
    WaypointsWorldSet _thisComponent;

    private void Start()
    {
        _realPositions = new Vector3[_positions.Length];
        for (int count = _constZero; count < _positions.Length; count++)
        {
            _realPositions[count] = _positions[count].TransformPoint(_realPositions[count]);
        }
        if (_alienEnemy == null)
        {
            _alienEnemy = GetComponent<AlienEnemy>();
        }
            _alienEnemy._realPositions = _realPositions;
        _thisComponent = GetComponent<WaypointsWorldSet>();
        Destroy(_thisComponent);
    }
}
