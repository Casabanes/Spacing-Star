using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryErrorsPrevent : MonoBehaviour
{
    [SerializeField]
    private PlayerExtras _playerExtras;
    [SerializeField]
    private CapsuleCollider2D _capsuleCollider;
    [SerializeField]
    private IsDamageable _isDamageable;
    [SerializeField]
    private PlayerSeccondaryShot _playerSeccondaryShot;
    [SerializeField]
    private PlayerPrimaryAttack _playerPrimaryAttack;
    [SerializeField]
    private PlayerMovment _playerMovment;
    private void Start()
    {
        if (_playerExtras == null)
        {
            _playerExtras = GetComponent<PlayerExtras>();
        }
        if (_capsuleCollider == null)
        {
            _capsuleCollider = GetComponent<CapsuleCollider2D>();
        }
        if (_isDamageable == null)
        {
            _isDamageable = GetComponent<IsDamageable>();
        }
        if (_playerSeccondaryShot == null)
        {
            _playerSeccondaryShot = GetComponent<PlayerSeccondaryShot>();
        }
        if (_playerPrimaryAttack == null)
        {
            _playerPrimaryAttack = GetComponent<PlayerPrimaryAttack>();
        }
        if (_playerMovment == null)
        {
            _playerMovment = GetComponent<PlayerMovment>();
        }
    }
    public void TurnOffProblematicThings()
    {
        _playerExtras.enabled = false;
        _capsuleCollider.enabled = false;
        _isDamageable.enabled = false;
        _playerSeccondaryShot.enabled = false;
        _playerPrimaryAttack.enabled = false;
        _playerMovment.enabled = false;

    }

}
