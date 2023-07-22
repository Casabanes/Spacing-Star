using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCannon : MonoBehaviour
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
    AlienShot _auxAlienShot;

    public int[] _layerEnemy;

    [SerializeField]
    Animator _animatorController;
    [SerializeField]
    bool _isShooting;
    void Start()
    {
        _player=FindObjectOfType<PlayerMovment>();
        if (_animatorController == null)
        {
            _animatorController = GetComponent<Animator>();
        }
    }

   
    public void Update()
    {
        if (_player != null)
        {
            DistanceCalculation();
            transform.up = (_player.transform.position - transform.position);
            transform.up = new Vector3(transform.up.x,transform.up.y,_constZero);
            Shoot();
        }
    }
    public void Shoot()
    {
        if (!_canShoot)
        {
            Rechargue();
            return;
        }
        if (_rangeToAtack > _distanceToPlayer)
        {
            for (int count = _constZero; count < _layerEnemy.Length; count++)
            {
                _alienShot._layerEnemy[count] = _layerEnemy[count];
            }
         
            _isShooting = true;
            _animatorController.SetBool("_isShooting", _isShooting);
            _canShoot = false;
        }
    }
    public void InstansiateShoot()
    {
        _auxAlienShot = Instantiate(_alienShot, transform.position + transform.up, transform.rotation);
        _isShooting = false;
        _animatorController.SetBool("_isShooting", _isShooting);

    }
    public void Rechargue()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _timeToShoot)
        {
            _canShoot = true;
            _currentTime = _constZero;
        }
    }
    public void DistanceCalculation()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
    }
}
