using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionAlien : MonoBehaviour
{
    public PlayerMovment _player;
    [SerializeField]
    public Rigidbody2D _rb;
    public float _persecutionRange;
    public float _distanceToPlayer;
    public float _speed;
    public float _originalSpeed;
    const int _constZero = 0;
    [SerializeField]
    float _distanceToContinue;
    [SerializeField]
    AlienEnemy _alienEnemy;
    void Start()
    {
        _player = FindObjectOfType<PlayerMovment>();
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        if (_alienEnemy == null)
        {
            _alienEnemy = GetComponent<AlienEnemy>();
        }
        _originalSpeed = _speed;
    }

    void Update()
    {
        if (_player != null)
            _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_persecutionRange > _distanceToPlayer)
        {
            if (_alienEnemy.isActiveAndEnabled == true)
            {
            _alienEnemy.enabled = false;
            }
            Movment();
        }
        else
        {
            _alienEnemy.enabled = true;
        _rb.velocity = transform.up * _constZero;
        }

    }
    void Movment()
    {
        if(_speed==_constZero&&_distanceToPlayer> _distanceToContinue)
        {
            _speed = _originalSpeed;
        }
        transform.up = -(transform.position - _player.transform.position);
        _rb.velocity = transform.up * _speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _player.gameObject.layer)
        {
            _speed = _constZero;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _player.gameObject.layer)
        {
            _speed = _constZero;
        }
    }
}
