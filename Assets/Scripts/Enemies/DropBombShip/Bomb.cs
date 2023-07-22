using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bomb : MonoBehaviour
{
    public IsDamageable _enemyID;
    private LayerMask _layerPlayer;
    SimpleIsDamageable _SimpleidDamageable;
    public CircleCollider2D _cc;
    public int _layerEnemy;
    public int _damage;
    public ParticleSystem _ps;
    public Rigidbody2D _rb;
    public float _time;
    public float _timeUntilAutoExplosion;
    public bool _isHard;
    [SerializeField]
    float _pushForce;
    [SerializeField]
    float _pushTime;
    public PlayerMovment _playerMovment;
    private void Start()
    {
        if (_cc == null)
        {
            _cc = GetComponent<CircleCollider2D>();
        }
        if (_SimpleidDamageable == null)
            _SimpleidDamageable = GetComponent<SimpleIsDamageable>();
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        if (_playerMovment != null)
        {
            _layerPlayer = _playerMovment.gameObject.layer;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _enemyID = collision.gameObject.GetComponent<IsDamageable>();
        if(_enemyID!=null)
        {
                _enemyID.TakeDamage(_damage);
        }
        if (_isHard)
        {
            if(collision.gameObject.layer== _layerPlayer)
            {
                _playerMovment.CallIsPushd(_pushTime, _playerMovment.transform.position - transform.position, _pushForce);
            }
        }
        _SimpleidDamageable._ps=_ps;
        _SimpleidDamageable.Death();
    }
    public void Impulse( Vector2 _direction, float _force)
    {
        _rb.AddForce(_direction * _force, ForceMode2D.Force);
    }
}
