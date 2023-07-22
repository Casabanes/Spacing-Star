using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecution : MonoBehaviour
{
    public PlayerMovment _player;
    [SerializeField]
    public Rigidbody2D _rb;
    public float _persecutionRange;
    public float _distanceToPlayer;
    public float _speed;
    void Start()
    {
        _player = FindObjectOfType<PlayerMovment>();
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_player != null)
        {
            _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_persecutionRange > _distanceToPlayer)
            Movment();
        }
    }
    void Movment()
    {

        transform.up = -(transform.position - _player.transform.position);
        _rb.velocity = transform.up * _speed;
    }
}
