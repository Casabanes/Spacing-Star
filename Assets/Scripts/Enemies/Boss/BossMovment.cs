using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovment : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    private MovmentModes _mode;

    [SerializeField]
    private float _angleSpeed;
    [SerializeField]
    private float _startingAngle;
    private float _angle;
    [SerializeField]
    private float _distanceToCenter;
    private Vector3 _center;
    [SerializeField]
    private Transform _centerObject;
    private const int _constZero = 0;

    [SerializeField]
    private PlayerMovment _player;

    [SerializeField]
    private float _toleranceToRotate;

    [SerializeField]
    private LookAtPlayerObject _lookAtPlayerObject;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _maxDistanceToLookAtPlayer;
    [SerializeField]
    private float _minDistanceToLookAtPlayer;
    [SerializeField]
    private Vector3 _initialRotation;
    [SerializeField]
    private float _timeToChangeMode;
    private Vector3 _destination;
    [SerializeField]
    private float _destinationDistanceToleration;
    private float _distanceToPlayer;
    private bool _hasCheckedAllAngles;
    private MovmentModes[] _modes=new MovmentModes[3];
    private void Start()
    {
        CheckIfPlayerIsAssigned();
        CheckIfLookAtPlayerObjectIsAssigned();
        CenterSet();
        StartCoroutine(ChangeMode(_modes[0]));
    }
    private void Update()
    {
        switch (_mode)
        {
            case (MovmentModes.RotationMode):
                RotationMovment();
                break;
            case (MovmentModes.PersecutionMode):
                PersecutionMovment();
                break;
            case (MovmentModes.GoingBackMode):
                GoBack();
                break;
        }
    }
    private void CenterSet()
    {
        _angle = _startingAngle;
        if (_centerObject == null)
        {
            _center = new Vector2(_constZero, _constZero);
            Debug.LogError("No hay objeto central asignado");
            return;
        }
        _center = new Vector2(_centerObject.transform.position.x, _centerObject.transform.position.y);
        Destroy(_centerObject.gameObject);
    }
    private void RotationMovment()
    {
        _destination = new Vector3(_center.x + Mathf.Cos(_angle) * _distanceToCenter, _center.y + Mathf.Sin(_angle) * _distanceToCenter);
        transform.position = _destination;
        transform.up = -(_center - transform.position);
        _angle += _angleSpeed * Time.deltaTime;
        LookAtPlayer();
    }
    private void PersecutionMovment()
    {
        _distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        if (_distanceToPlayer <= _minDistanceToLookAtPlayer)
        {
            return;
        }
        else
        {
            transform.position += (_player.transform.position - transform.position).normalized * _speed * Time.deltaTime;
            LookAtPlayer();
        }
    }
    private void LookAtPlayer()
    {
        transform.up = -_lookAtPlayerObject.transform.right;
    }
    private void CheckIfPlayerIsAssigned()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerMovment>();
            if (_player == null)
            {
                Debug.LogError("No se encontró al objeto Player");
                return;
            }
        }
    }
    private void CheckIfLookAtPlayerObjectIsAssigned()
    {
        if (_lookAtPlayerObject == null)
        {
            Debug.LogError("El objeto LookAtPlayerObject no fue asignado");
        }
        if (!_lookAtPlayerObject.isActiveAndEnabled)
        {
            _lookAtPlayerObject = Instantiate(_lookAtPlayerObject);
        }
        if (_lookAtPlayerObject.isActiveAndEnabled && _lookAtPlayerObject != null)
        {
            _lookAtPlayerObject.SetRotationSpeed(_rotationSpeed);
            _lookAtPlayerObject.SetMinDistanceToLookAtPlayer(_minDistanceToLookAtPlayer);
            _lookAtPlayerObject.SetMaxDistanceToLookAtPlayer(_maxDistanceToLookAtPlayer);
            _lookAtPlayerObject.SetObjectToFollow(transform);
            _lookAtPlayerObject.SetInitialRotation(_initialRotation);
        }
    }
    private void GoBack()
    {
        if (!_hasCheckedAllAngles)
        {
            for (int i = _constZero; i < 360; i++)
                {
                if(Vector3.Distance( _destination, transform.position) 
                 > Vector3.Distance(new Vector3(_center.x + Mathf.Cos(i)
                 * _distanceToCenter, _center.y + Mathf.Sin(i) * _distanceToCenter), transform.position))
                 {
                    _angle = i;
                    _destination = new Vector3(_center.x + Mathf.Cos(i) * _distanceToCenter, _center.y + Mathf.Sin(_angle) * _distanceToCenter);
                 }
            }
        }
        _destination = new Vector3(_center.x + Mathf.Cos(_angle) * _distanceToCenter, _center.y + Mathf.Sin(_angle) * _distanceToCenter);
        transform.position += (_destination - transform.position).normalized * _speed * Time.deltaTime;
        LookAtPlayer();
        if (transform.position.x >= _destination.x - _destinationDistanceToleration &&
            transform.position.x <= _destination.x + _destinationDistanceToleration &&
            transform.position.y >= _destination.y - _destinationDistanceToleration &&
            transform.position.y <= _destination.y + _destinationDistanceToleration)
        {
            _mode = MovmentModes.RotationMode;
            StartCoroutine(ChangeMode(_modes[2]));
        }
    }
    private IEnumerator ChangeMode(MovmentModes mode)
    {
        if (_timeToChangeMode == _constZero)
        {
            Debug.LogError("_timeToChangeMode no fue asignado");
            yield break;
        }
        yield return new WaitForSeconds(_timeToChangeMode);

		switch (mode)
		{
			case (MovmentModes.RotationMode):
                _mode = MovmentModes.RotationMode;
                StartCoroutine(ChangeMode(_modes[0]));
				break;
	        case (MovmentModes.PersecutionMode):
                _mode = MovmentModes.PersecutionMode;
                StartCoroutine(ChangeMode(_modes[1]));
                break;
            case (MovmentModes.GoingBackMode):
                _mode = MovmentModes.GoingBackMode;
                break;
        }
    }
    private enum MovmentModes
    {
        RotationMode, PersecutionMode, GoingBackMode
    }
    public void SetDifficulty(int newDifficulty)
    {
        switch (newDifficulty)
        {
            case (0):
                StopCoroutine(ChangeMode((_modes[1])));
                _mode = MovmentModes.GoingBackMode;
                _modes[0] = MovmentModes.RotationMode;
                _modes[1] = MovmentModes.GoingBackMode;
                _modes[2] = MovmentModes.RotationMode;
                StartCoroutine(ChangeMode(_modes[1]));
                break;
            case (1):
                StopCoroutine(ChangeMode((_modes[0])));
                _modes[0] = MovmentModes.PersecutionMode;
                _modes[1] = MovmentModes.GoingBackMode;
                _modes[2] = MovmentModes.RotationMode;
                StartCoroutine(ChangeMode(_modes[0]));
                break;
            case (2):
                StopCoroutine(ChangeMode((_modes[0])));
                _mode = MovmentModes.PersecutionMode;
                _modes[0] = MovmentModes.PersecutionMode;
                _modes[1] = MovmentModes.PersecutionMode;
                _modes[2] = MovmentModes.PersecutionMode;
                StartCoroutine(ChangeMode(_modes[0]));
                break;
        }
    }
}
