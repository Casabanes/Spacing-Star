using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    [SerializeField]
    private PlayerMovment _playerMovment;
    [SerializeField]
    private float _speedBuff;
    private float _orSpeedBuff;
    [SerializeField]
    private float _speedBuffCap;
    private float _orSpeedBuffCap;
    [SerializeField]
    private float _time;
    private const int _constZero = 0;
    private const int _constOne = 1;

    void Start()
    {
        if(_playerMovment==null)
        {
            _playerMovment = GetComponent<PlayerMovment>();
        }
    }
    public void StartSpeedUp(float speedBuff,float time)
    {
        _speedBuff = speedBuff;
        _time += time;
        SpeedUp();
    }
    private void Update()
    {
        if(_time> _constZero)
        {
            _time -= Time.deltaTime;
            if (_time <= _constZero)
            {
                ReturnToNormalValues();
            }
        }
    }
    private void SpeedUp()
    {
        _orSpeedBuff = _playerMovment._buffSpeed;
        _playerMovment._buffSpeed = _speedBuff;
    }
    private void ReturnToNormalValues()
    {
        _playerMovment._buffSpeed = _orSpeedBuff;
        _playerMovment._buffSpeedCap = _orSpeedBuffCap;
    }
}
