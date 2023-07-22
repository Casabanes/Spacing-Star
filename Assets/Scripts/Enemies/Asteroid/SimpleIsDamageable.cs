using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleIsDamageable : MonoBehaviour
{

    public float _life;
    public float _maxLife;
    const int _constZero = 0;
    public ParticleSystem _ps;
    public Vector3 _explosionSize;
    public bool _isInvulnerable;
    public float _currentTime;
    public float _maxTime;

    public SpriteRenderer _sr;


    public int _layerEnemy;
    public int _layerOfThis;
    public int _layerInvulnerable;


    Canvas _canvas;

    void Start()
    {
        _life = _maxLife;

        if (_sr == null )
            _sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        InvulnerableTime();
    }
    public void TakeDamage(int _damage)
    {
        if (_isInvulnerable)
            return;
        _life -= _damage;

        if (_life <= _constZero)
        {
            _life = _constZero;
            Death();
        }
        _isInvulnerable = true;
    }




    void InvulnerableTime()
    {
        if (_isInvulnerable)
        {
            _currentTime += Time.deltaTime;
          
            if (_currentTime >= _maxTime)
            {
         
                gameObject.layer = _layerOfThis;
                _currentTime = _constZero;
                _isInvulnerable = false;
            }
        }
    }


    public void Death()
    {
        _ps.transform.localScale = _explosionSize;
        Instantiate(_ps, transform.position, _ps.transform.rotation);
        _ps.Play();
        Destroy(gameObject);
    }
}
