using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurbo : MonoBehaviour
{
    BaseBrain _brain;
    [SerializeField]
    private bool _theBrainIsCreatedExternaly;

    const int _constZero = 0;
    const int _constOne = 1;

    float _orSpeed;   //turbo variables
    public float _turboSpeed;
    public float _turboSpeedCap;
    public float _turboValue;
    public float _turboMaxValue;
    public int _turboprice;
    public Image _turboBar;
    public bool _isInTurboMode;  //turbo variables
    public IsDamageable _id;
    public float _orSpeedCap;

    float _speed;
    float _speedCap;

    public int _turboChargue;//rechargue turbo variables

    [SerializeField]
    PlayerMovment _playerMovment;

    void Start()
    {
        if (!_theBrainIsCreatedExternaly)
        {
            _brain = new Brain { _playerTurbo = this };
        }
        if (_id == null)
        {
            _id = GetComponent<IsDamageable>();
        }
        if (_id != null)
        {
        _turboBar = _id._followLiveEntity._turboBar;
        }
        _turboValue = _turboMaxValue;
        if (_playerMovment == null)
        {
            _playerMovment = GetComponent<PlayerMovment>();
        }
        if (_playerMovment != null)
        {
        _orSpeed = _playerMovment._speed;
        _orSpeedCap = _playerMovment._speedCap;
        }

    }

    void Update()
    {
        _brain.Listen_Keys();
        TurboRechargue();
    }
    public void Turbo()
    {
        if (_turboValue < _turboprice * Time.deltaTime)
        {
            _isInTurboMode = false;
            return;
        }
        _speed = _orSpeed + _turboSpeed; //esta formula es así para que el turbo siempre sea más rápido que la velocidad original
        _speedCap = _orSpeedCap + _turboSpeedCap;
        _playerMovment.TurboMode(_constOne, _speed, _speedCap);
        _isInTurboMode = true;


            _turboValue -= _turboprice* Time.deltaTime;
            if (_turboValue < _constZero)
                _turboValue = _constZero;
            _turboBar.fillAmount = _turboValue / _turboMaxValue;
        
    }

    public void TurboRechargue()
    {
        if (!_isInTurboMode)
        {

            if (_speed > _orSpeed)
            {
                _speed -= _speed / _speed / _playerMovment._inertiaDuration;
            }
            if (_speed < _orSpeed)
                _speed = _orSpeed;
            if (_speedCap > _orSpeedCap)
            {
                _speedCap -= _speedCap / _speedCap / _playerMovment._inertiaDuration;
            }
            if (_speedCap < _orSpeedCap)
                _speedCap = _orSpeedCap;
            if (_turboValue == _turboMaxValue)
                return;
                _turboValue += _turboChargue * Time.deltaTime;
                if (_turboValue > _turboMaxValue)
                    _turboValue = _turboMaxValue;
                _turboBar.fillAmount = _turboValue / _turboMaxValue;
            _playerMovment.TurboMode(_playerMovment._midMovmentAudioVolume, _speed, _speedCap);
        }
    }
    public void SetBrain(BaseBrain brain)
    {
        _brain = brain;
    }
}
