using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBrain
{
    public PlayerMovment _playerMovment;
    public PlayerTurbo _playerTurbo;
    public PlayerSeccondaryShot _playerSeccondaryShot;

    public const int _constZero = 0;
    public virtual void Listen_Keys()
    {
        if (_playerMovment != null)
        {
            _playerMovment.Movment(Input.GetAxisRaw("Vertical"));
            _playerMovment.Rotation(Input.GetAxisRaw("Horizontal"));
            _playerMovment._animatorController.SetInteger("_isSpining", (int)Input.GetAxisRaw("Horizontal"));
        }
        if (_playerSeccondaryShot != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                _playerSeccondaryShot.ShotP();
        }
        if (_playerTurbo != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetAxisRaw("Vertical") != _constZero || Input.GetKey(KeyCode.Space) && Input.GetAxisRaw("Vertical") != _constZero)
                _playerTurbo.Turbo();
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetAxisRaw("Vertical") == _constZero)
                _playerTurbo._isInTurboMode = false;
        }
    }
}
