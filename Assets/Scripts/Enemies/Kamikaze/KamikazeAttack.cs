using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeAttack : MonoBehaviour
{
    public PlayerMovment _player;
    private LayerMask _layerPlayer;
    [SerializeField]
    private IsDamageable _id;
    private IsDamageable _enemyID;
    public ParticleSystem _ps;
    public int _damage;
    public bool _isNormalOrMore;
    [SerializeField]
    float _pushForce;
    [SerializeField]
    float _pushTime;


    void Start()
    {
        if (_id == null)
            _id = GetComponent<IsDamageable>();
        _player = FindObjectOfType<PlayerMovment>();
        if (_player != null)
        {
            _layerPlayer = _player.gameObject.layer;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            AtackKamikaze();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            AtackKamikaze();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            AtackKamikaze();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            AtackKamikaze();
        }
    }
    void AtackKamikaze()
    {
        if (_player != null)
        {
            _enemyID = _player.GetComponent<IsDamageable>();
            _enemyID.TakeDamage(_damage);
            if (_isNormalOrMore)
            {
            _player.CallIsPushd(_pushTime,_player.transform.position-transform.position, _pushForce);
            }
        }
        _id._ps = _ps;
        _id.Death();
    }
}
