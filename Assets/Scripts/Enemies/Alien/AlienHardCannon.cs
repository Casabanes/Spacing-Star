using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHardCannon : MonoBehaviour
{
 
    public bool _enemmyInRange;
    public float _currentTime;
    public float _timeToShoot;
    public bool _canShoot;
    const int _constZero=0;
    public PlayerMovment _player;
    public float _rangeToAtack;
    public float _distanceToPlayer;
    public GameObject _alienShotFather;
    public AlienShot _alienShot;
    public int[] _layerEnemy;
    public Rigidbody2D _rb;
    Vector3 _direction;
    Transform _parentTransform;
    [SerializeField]
    int _shotsQuantity;
    int _currentShoot;
    [SerializeField]
    float _timeToNextShoot;
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        if (_rb == null)
        {
            _rb.GetComponentInParent<Rigidbody2D>();
        }
        _player=FindObjectOfType<PlayerMovment>();
        _parentTransform = GetComponentInParent<Transform>();
        _alienShot = _alienShotFather.GetComponentInChildren<AlienShot>();
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
            if (_currentShoot < _shotsQuantity)
            {
               StartCoroutine(Shoting());
            }

            _canShoot = false;
            _currentShoot = _constZero;
        }
        else
        {
            Rechargue();
        }
    }
    private IEnumerator Shoting()
    {
        for (_currentShoot = _constZero; _currentShoot < _shotsQuantity; _currentShoot++)
        {
            _alienShot._isHard = true;
            _animator.SetBool("_isShooting", true);
            Instantiate(_alienShotFather, transform.position + transform.up, transform.rotation);
            _animator.SetBool("_isShooting", false);
            yield return new WaitForSeconds(_timeToNextShoot);
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
        _distanceToPlayer = Vector3.Distance(_parentTransform.position, _player.transform.position);
        if (_distanceToPlayer <= _rangeToAtack)
        {
        _direction = _parentTransform.position - _player.transform.position;
            Shoot();
        }
    }
}
