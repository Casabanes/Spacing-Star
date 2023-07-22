using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBrain : BaseBrain
{
    public PlayerPrimaryAttack _playerPrimaryAttack;
    private BrainModes _mode;
    private TutorialInstructions _tutorialInstructions;
    public enum BrainModes
    {
        Inactive,VerticalMovment,HorizontalMovment,MovmentAndTurbo,PrimaryShot,MovmentAndPrimaryShot
            ,SeccondaryShot,AllActions,MovmentAndShots
    }
    public override void Listen_Keys()
    {
        switch(_mode)
        {
            case (BrainModes.Inactive):
                break;
            case (BrainModes.VerticalMovment):
                Movment();
                break;
            case (BrainModes.HorizontalMovment):
                Movment();
                Rotation();
                break;
            case (BrainModes.MovmentAndTurbo):
                Movment();
                Rotation();
                Turbo();
                break;
            case (BrainModes.PrimaryShot):
                PrimaryAttack();
                break;
            case (BrainModes.MovmentAndPrimaryShot):
                Movment();
                Rotation();
                Turbo();
                PrimaryAttack();
                break;
            case (BrainModes.MovmentAndShots):
                Movment();
                Rotation();
                PrimaryAttack();
                SecondaryShot();
                break;
            case (BrainModes.SeccondaryShot):
                SecondaryShot();
                break;
            case (BrainModes.AllActions):
                Movment();
                Rotation();
                Turbo();
                PrimaryAttack();
                SecondaryShot();
                break;
        }
    }
    public void SetMode(BrainModes mode)
    {
        _mode = mode;
    }
    private void Movment()
    {
        if (_playerMovment != null)
        {
            _playerMovment.Movment(Input.GetAxisRaw("Vertical"));
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
    private void Rotation()
    {
        if (_playerMovment != null)
        {
            _playerMovment.Rotation(Input.GetAxisRaw("Horizontal"));
            _playerMovment._animatorController.SetInteger("_isSpining", (int)Input.GetAxisRaw("Horizontal"));
        }
    }
    private void PrimaryAttack()
    {
        if (_playerPrimaryAttack != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
            {
                _playerPrimaryAttack.ShotS();
                _tutorialInstructions.ThePlayerHasShooted();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _playerPrimaryAttack.RestS();
            }
        }
    }
    private void SecondaryShot()
    {
        if (_playerSeccondaryShot != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _playerSeccondaryShot.ShotP();
                _tutorialInstructions.ThePlayerHasHeavyShooted();
            }
        }
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
    public void SetSecondaryShoot(PlayerSeccondaryShot playerSeccondaryShot)
    {
        _playerSeccondaryShot = playerSeccondaryShot;
        _playerSeccondaryShot.SetBrain(this);
    }
    public void SetPrimaryShoot(PlayerPrimaryAttack playerPrimaryAttack)
    {
        _playerPrimaryAttack = playerPrimaryAttack;
        _playerPrimaryAttack.SetBrain(this);
    }
    public void SetTutorialInstructions(TutorialInstructions tutorialInstructions)
    {
        _tutorialInstructions = tutorialInstructions;
    }
}
