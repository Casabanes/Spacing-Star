using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCannon : MonoBehaviour
{
 
    public bool _enemmyInRange;
    public float _currentTime;
    public float _timeToShoot;
    public bool _canShoot;
    const int _constZero=0;
    public PlayerMovment _player;
    public float _rangeToAtack;
    public float _distanceToPlayer;
    public AlienShot _alienShot;
    public int[] _layerEnemy;
    Vector3 _direction;
    Transform _parentTransform;
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        _player=FindObjectOfType<PlayerMovment>();
        _parentTransform = GetComponentInParent<Transform>();
    }

   
    public void Update()
    {
        if (_player != null)
        {
            transform.up = (_player.transform.position - transform.position);
            DistanceCalculation();
        }
    }
    public void Shoot()
    {
        if(_canShoot)
        {
            for (int count = _constZero; count < _layerEnemy.Length; count++)
            {
                _alienShot._layerEnemy[count] = _layerEnemy[count];
            }
            _alienShot._isHard = false;
            _animator.SetBool("_isShooting", true);
            Instantiate(_alienShot, transform.position + transform.up, transform.rotation);
            _canShoot = false;
        }
        else
        {
            Rechargue();
        }
    }
    public void Rechargue()
    {
        _animator.SetBool("_isShooting", false);
        _currentTime += Time.deltaTime;
        if (_currentTime >= _timeToShoot)
        {
            _canShoot = true;
            _currentTime = _constZero;
        }
    }
    public void DistanceCalculation()
    {
        _distanceToPlayer = Vector3.Distance(_parentTransform.position, _player.transform.position);
        if (_distanceToPlayer <= _rangeToAtack)
        {
            _direction = _parentTransform.position - _player.transform.position;
            Shoot();
        }
    }
}
