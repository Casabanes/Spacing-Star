using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBrain : BaseBrain
{
    public MainMenuInstructions _mainMenuInstructions;
    private BrainMode _brainMode;
    private float _direction;
    public override void Listen_Keys()
    {
        switch (_brainMode)
        {
            case (BrainMode.Free):
                Movment();
                SecondaryShot();
                Turbo();
                break;
            case (BrainMode.Moving):
                if (_playerMovment != null)
                {
                    _playerMovment.Movment(_direction);
                }
                break;
            case (BrainMode.Shoting):
                if (_playerSeccondaryShot != null)
                {
                    _playerSeccondaryShot.ShotP();
                    _brainMode = BrainMode.Free;
                }
                break;
        }
    }
    public enum BrainMode
    {
        Free,Shoting,Moving
    };
    private void Movment()
    {
        if (_playerMovment != null)
        {
            _playerMovment.Movment(Input.GetAxisRaw("Vertical"));
            _playerMovment.Rotation(Input.GetAxisRaw("Horizontal"));
            _playerMovment._animatorController.SetInteger("_isSpining", (int)Input.GetAxisRaw("Horizontal"));
        }
    }
    private void Turbo()
    {
        if (_playerTurbo != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetAxisRaw("Vertical") != _constZero || Input.GetKey(KeyCode.Space) && Input.GetAxisRaw("Vertical") != _constZero)
            {
                _playerTurbo.Turbo();
            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetAxisRaw("Vertical") == _constZero)
            {
                _playerTurbo._isInTurboMode = false;
            }
        }
    }
    private void SecondaryShot()
    {
        if (_playerSeccondaryShot != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                _playerSeccondaryShot.ShotP();
        }
    }
    public void SetBrainMode(BrainMode brainMode)
    {
        _brainMode = brainMode;
    }
    public void SetDirection(float direction)
    {
        _direction = direction;
    }
    public void SetSecondaryShoot(PlayerSeccondaryShot playerSeccondaryShot)
    {
        _playerSeccondaryShot = playerSeccondaryShot;
        _playerSeccondaryShot.SetBrain(this);
    }
    public void SetPlayerMovment(PlayerMovment playerMovment)
    {
        _playerMovment = playerMovment;
        _playerMovment.SetBrain(this);
    }
    public void SetPlayerTurbo(PlayerTurbo playerTurbo)
    {
        _playerTurbo = playerTurbo;
        _playerTurbo.SetBrain(this);
    }
}
