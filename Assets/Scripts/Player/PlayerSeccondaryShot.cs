using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeccondaryShot : MonoBehaviour
{
    BaseBrain _brain;
    [SerializeField]
    private bool _theBrainIsCreatedExternaly;
    public ShotP _shotP; //shotP variables
    public float _currentTime;
    public float _shotPCD;
    bool _isShoting;     //shotP variables
    const int _constZero = 0;
    const int _constOne = 1;
    public int[] _layerEnemy;
    void Start()
    {
        if (!_theBrainIsCreatedExternaly)
        {
            _brain = new Brain { _playerSeccondaryShot = this };
        }

    }
    private void Update()
    {
        _brain.Listen_Keys();
        Rechargue();
    }
    public void ShotP()
    {
        if (_isShoting)
            return;
        for (int count = _constZero; count < _layerEnemy.Length; count++)
        {
            _shotP._layerEnemy[count] = _layerEnemy[count];
        }
        Instantiate(_shotP, transform.position + transform.up, transform.rotation);
        _isShoting = true;
    }
    public void Rechargue()
    {
        if (!_isShoting)
            return;
        _currentTime += Time.deltaTime;
        if (_currentTime >= _shotPCD)
        {
            _currentTime = _constZero;
            _isShoting = false;
        }
    }
    public void SetBrain(BaseBrain brain)
    {
        _brain = brain;
    }
}

