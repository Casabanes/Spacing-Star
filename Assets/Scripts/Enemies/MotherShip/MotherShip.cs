using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public IgnoreMotherShip _kamikaze;
    public float _maxOfEnemiesInScreen;
    public IgnoreMotherShip[] _kamikazeReferenceForCount;
    public float _time;
    public float _timeToSpawn;
    public float _time2;
    public float _timeToWaitIfItsFull;
    const int _constZero = 0;
    const int _constOne = 1;
    public int _count;
    public bool _areFull;
    public PlayerMovment _player;
    public float _distanceToPlayer;
    public float _spawnRange;
    public BoxCollider2D _bc;

    public bool _isHard;
    [SerializeField]
    IsDamageable _isDamageable;
    [SerializeField]
    float _regenerationAmount;
    private void Start()
    {
        _kamikazeReferenceForCount = new IgnoreMotherShip[(int)_maxOfEnemiesInScreen];
        for (_count = _constZero; _count < _maxOfEnemiesInScreen; _count++)
        {
        _kamikazeReferenceForCount[_count]=null;
        }
        _count = _constZero;
        _player = FindObjectOfType<PlayerMovment>();
        if(_isDamageable==null)
        {
            _isDamageable = GetComponent<IsDamageable>();
        }
    }
    void Update()
    {
        if (_player != null)
            _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_spawnRange > _distanceToPlayer)
        {
        _time += Time.deltaTime;
        if (_time >= _timeToSpawn)
        {
            if (!_areFull)
            {
                for (_count = _constZero; _count < _maxOfEnemiesInScreen; _count++)
                {
                    if (_kamikazeReferenceForCount[_count] == null)
                    {
                        _kamikaze._bc.isTrigger = true;
                        _kamikazeReferenceForCount[_count] = Instantiate(_kamikaze, transform.position, transform.rotation);
                        _time = _constZero;
                        break;
                    }
                    else if (_count + _constOne == _maxOfEnemiesInScreen)
                    {
                        _areFull = true;
                    }
                }
            }
        else
        {
            _time2 += Time.deltaTime;
            if (_time2 >= _timeToWaitIfItsFull)
            {
                _areFull = false;
                _time2 = _constZero;
            }
        }
        }
        }
        Regeneration();
    }
    private void Regeneration()
    {
        if (!_isHard)
        {
            return;
        }
        _isDamageable._life += _regenerationAmount * Time.deltaTime;
        if (_isDamageable._life > _isDamageable._maxLife)
        {
            _isDamageable._life = _isDamageable._maxLife;
        }
        _isDamageable._lifebar.fillAmount = _isDamageable._life / _isDamageable._maxLife;
    }
}
