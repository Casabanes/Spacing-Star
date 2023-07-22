using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemy : MonoBehaviour
{
    public Rigidbody2D _rb;
  
    public int _i;
    public Vector2 _dir;
    const int _constZero=0;
    const int _constOne=1;
    public Vector3[] _realPositions;
    public bool _fowardOrBackward;
    public float _rangeToChange;
    public float _speed;
    public bool _goToTheFirstPoint;
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _fowardOrBackward = true;
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.up = _dir.normalized;
        _dir = (_realPositions[_i] - transform.position);
        _rb.velocity = _dir.normalized*_speed;
        if (Vector3.Distance(_realPositions[_i], transform.position) < _rangeToChange)
        {
            if (_fowardOrBackward)
            {
                if (_i != _realPositions.Length - _constOne)
                    _i++;
                else
                {
                    if (_goToTheFirstPoint)
                    {
                        _i = _constZero;
                    }
                    else
                    {
                    _i--;
                    _fowardOrBackward = false;
                    }
                }
            }
            else
            {
                if (_i != _constZero)
                    _i--;
                else
                {
                    if (_goToTheFirstPoint)
                    {
                        _i = _realPositions.Length-_constOne;
                    }
                    else
                    {
                        _i++;
                    _fowardOrBackward = true;
                    }
                }
            }
        }
    }
    }

