using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBombCannon : MonoBehaviour
{
 
    public bool _enemmyInRange;
    public float _currentTime;
    public float _timeToShoot;
    public bool _canShoot;
    const int _constZero=0;
    public PlayerMovment _player;
    public float _rangeToAtack;
    public float _distanceToPlayer;
    public DropBombShoot _dropBombShot;
    DropBombShoot _auxDropBombShot;

    public int[] _layerEnemy;

    [SerializeField]
    Animator _animatorController;
    [SerializeField]
    bool _isShooting;
    [SerializeField]
    Transform _shootPos;
    [SerializeField]
    private float[] _timeToShootDependingDifficulty;

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
            }
         
            _isShooting = true;
            _animatorController.SetBool("_isShooting", _isShooting);
            _canShoot = false;
        }
    }
    public void InstansiateShoot()
    {
        if (_shootPos != null)
        {
        _auxDropBombShot = Instantiate(_dropBombShot, _shootPos.position, transform.rotation);
        _isShooting = false;
        _animatorController.SetBool("_isShooting", _isShooting);
        }

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
    public void SetDifficulty(int newDifficulty)
    {
        _timeToShoot = _timeToShootDependingDifficulty[newDifficulty];
    }
}
