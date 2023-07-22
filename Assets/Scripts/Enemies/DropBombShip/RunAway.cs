using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public PlayerMovment _player;
    [SerializeField]
    public Rigidbody2D _rb;
    public float _persecutionRange;
    public float _distanceToPlayer;
    public float _speed;
    const int _constZero = 0;
    public float _time2;
    public float _timeToChangeDirection;
    public float _time3;
    public float _timecdToReact;

    void Start()
    {
        _player = FindObjectOfType<PlayerMovment>();
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        
        _time3 = _timecdToReact;
    }
    void Update()
    {
        if (_player != null)
            _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_persecutionRange > _distanceToPlayer)
        {
            Movment();
        }
        _time3 += Time.deltaTime;
    }
    void Movment()
    {
        _time2 += Time.deltaTime;

        if (_time2 >= _timeToChangeDirection)
        {
            transform.up = (transform.position - _player.transform.position);
            _time2 = _constZero;
        }
        _rb.velocity = transform.up * _speed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_time3 >= _timecdToReact)
        {
            transform.up = (transform.up - transform.right);
            _time3 = _constZero;
        }
    }
}
