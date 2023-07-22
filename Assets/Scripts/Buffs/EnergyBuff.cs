using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBuff : MonoBehaviour
{
    private PlayerTurbo _playerTurbo;
    private float _time;
    private float _energyBuff;
    private bool _isCharging;
    private const int _constZero=0;

    private void Start()
    {
        if (_playerTurbo == null)
        {
            _playerTurbo = GetComponent<PlayerTurbo>();
        }
    }
    public void StartChargingEnergy(float energyBuff,float time)
    {
        _energyBuff = energyBuff;
        _time += time;
    }
    private void Update()
    {
        Charging();
    }
    private void Charging()
    {
        if(_time> _constZero)
        {
            _playerTurbo._turboValue += _energyBuff * Time.deltaTime;
            _time -= Time.deltaTime;
        }
    }
}
