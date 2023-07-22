using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerObject : MonoBehaviour
{
    private float _rotationSpeed;
    private Vector3 _rotationDirection;
    private Quaternion _lookRotation;
    private float _maxDistanceToLookAtPlayer;
    private float _minDistanceToLookAtPlayer;
    [SerializeField]
    private PlayerMovment _player;
    private float _distanceToPlayer;
    private const int _constZero = 0;
    private Transform _objectToFollow;
    private float _angle;
    private void Start()
    {
        CheckIfPlayerIsAssigned();
        RotationThings();
    }
    private void Update()
    {
        LookAtPlayer();
        FollowObjectDesigned();
    }
    private void LookAtPlayer()
    {
        _distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        if (_distanceToPlayer <= _maxDistanceToLookAtPlayer && _distanceToPlayer>=_minDistanceToLookAtPlayer)
        {
            RotationThings();
        }
    }
    private void RotationThings()
    {
        _rotationDirection = _player.transform.position - transform.position;
        _angle = Mathf.Atan2(_rotationDirection.y, _rotationDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
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
    public void SetRotationSpeed(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }
    public void SetObjectToFollow(Transform transformToFollow)
    {
        _objectToFollow = transformToFollow;
    }
    public void SetMaxDistanceToLookAtPlayer(float maxdistanceToLookAtPlayer)
    {
        _maxDistanceToLookAtPlayer = maxdistanceToLookAtPlayer;
    }
    public void SetMinDistanceToLookAtPlayer(float mindistanceToLookAtPlayer)
    {
        _minDistanceToLookAtPlayer = mindistanceToLookAtPlayer;
    }
    public void SetInitialRotation(Vector3 initialRotation)
    {
        transform.rotation= Quaternion.Euler(initialRotation.x, initialRotation.y, initialRotation.z);
    }
    private void FollowObjectDesigned()
    {
        if (_objectToFollow == null)
        {
            Destroy(this.gameObject);
        }
        if (_objectToFollow == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = _objectToFollow.position;
        }
    }
}
