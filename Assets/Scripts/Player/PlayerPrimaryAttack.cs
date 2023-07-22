using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : MonoBehaviour
{
    BaseBrain _brain;
    public ShotS _shotS; //shotS variables
    public float _currentSTime;
    public Transform _lCanonShotPosition;
    public Transform _rCanonShotPosition;
    public float _shotSCD;
    public bool _shootInterpolation;
    public bool _isShotingS;     //shotS variables
    public int[] _layerEnemy;

    public Cannon[] _cannon;
    const int _constZero = 0;
    const int _constOne = 1;
    public Sight _sight;

    private bool _isBuffed;
    private GameObject _buffedShot;
    [SerializeField]
    private bool _theBrainIsCreatedExternaly;
    private float _time;

    void Start()
    {
        if (!_theBrainIsCreatedExternaly)
        {
            _brain = new Brain { _playerPrimaryAttack = this };
        }
        if (FindObjectOfType<Sight>() != null)
        {
         _sight = FindObjectOfType<Sight>();
        }
    }
    void Update()
    {
        _brain.Listen_Keys();
        RechargueS();
        Buffed(_constZero);
    }
    public void RestS()
    {
        _sight._resting = true;
    }
    public void ShotS()
    {
        _sight._resting = false;
        _sight.Rotation();
        if (_isShotingS)
            return;
        _isShotingS = true;
        for (int count = _constZero; count < _layerEnemy.Length; count++)
        {
            _shotS._layerEnemy[count] = _layerEnemy[count];
        }
        if (_shootInterpolation)
        {
            _shotS.transform.up = _cannon[_constOne].transform.up;
            _shotS._dir.z = _constZero;
            if (!_isBuffed)
            { 
                ShotS _shotSTempl = Instantiate(_shotS);
                _shotSTempl.transform.position = _lCanonShotPosition.position;
            }
            else
            {
                GameObject _buffShotTemporal= Instantiate(_buffedShot);
                _buffShotTemporal.transform.position = _lCanonShotPosition.position;
                _buffShotTemporal.transform.up = _cannon[_constOne].transform.up;
            }
            _cannon[_constZero].Shoot(false);
            _cannon[_constOne].Shoot(_isShotingS);
            _shootInterpolation = false;
        }
        else
        {
            _shotS.transform.up = _cannon[_constZero].transform.up;
            _shotS._dir.z = _constZero;
            if (!_isBuffed)
            {
                ShotS _shotSTempr = Instantiate(_shotS);
                _shotSTempr.transform.position = _rCanonShotPosition.position;
            }
            else
            {
                GameObject _buffShotTemporal = Instantiate(_buffedShot);
                _buffShotTemporal.transform.position = _rCanonShotPosition.position;
                _buffShotTemporal.transform.up= _cannon[_constZero].transform.up;
            }
            _cannon[_constOne].Shoot(false);
            _cannon[_constZero].Shoot(_isShotingS);
            _shootInterpolation = true;
        }

    }
    public void RechargueS()
    {
        if (!_isShotingS)
            return;
        _currentSTime += Time.deltaTime;
        if (_currentSTime >= _shotSCD)
        {
            _currentSTime = _constZero;
            _isShotingS = false;
        }
    }
    public void ChangeShot(GameObject _shot, float _time)
    {
        _buffedShot = _shot;
        _isBuffed = true;
        Buffed(_time);
    }
    private void Buffed(float time)
    {
        _time += time;
            if (_time > _constZero)
            {
                _time -= Time.deltaTime;
                if (_time <= _constZero)
                {
                    _isBuffed = false;
                }
            }
    }
   
    public void SetBrain(BaseBrain brain)
    {
        _brain = brain;
    }
}
