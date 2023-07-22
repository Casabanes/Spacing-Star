using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : BaseBrain
{
    public PlayerPrimaryAttack _playerPrimaryAttack;

    public override void Listen_Keys()
    {
        base.Listen_Keys();
        if (_playerPrimaryAttack != null)
        {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
                _playerPrimaryAttack.ShotS();
        if (Input.GetKeyUp(KeyCode.Mouse0))
                _playerPrimaryAttack.RestS();
        }
    }
}
