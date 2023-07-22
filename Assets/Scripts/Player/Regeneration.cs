using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration : MonoBehaviour
{
    [SerializeField]
    private IsDamageable _isDamageable;
    private bool _isHealing;
    private float _regenerationAmount;
    private float _time;
    private const int _constZero=0;
    void Start()
    {
        if (_isDamageable == null)
        {
            _isDamageable = GetComponent<IsDamageable>();
        }
    }
    private void Update()
    {
        RegenerationOverTime();
    }
    private void RegenerationOverTime()
    {
        if (_time > _constZero)
        {
            _isDamageable._life += _regenerationAmount * Time.deltaTime;
            if (_isDamageable._life > _isDamageable._maxLife)
            {
                _isDamageable._life = _isDamageable._maxLife;
            }
            _isDamageable._lifebar.fillAmount = _isDamageable._life / _isDamageable._maxLife;
            _time -= Time.deltaTime;
        }
    }
    public void StartRegeneration(float _regeneration, float time)
    {
        _time += time;
        _regenerationAmount = _regeneration;
    }
}
