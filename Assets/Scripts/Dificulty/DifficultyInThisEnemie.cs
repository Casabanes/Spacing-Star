using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyInThisEnemie : MonoBehaviour
{
    const int _constZero = 0;
    [SerializeField]
    Dificult_Selector _startDifficulty;
    [SerializeField]
    enum _enemyType
    {
        Alien=0,Kamikaze=1,MotherShip=2,DropBomb=3,Boss=4,DropBombCannon=5
    };
    [SerializeField]
    _enemyType _typeOfEnemie;
    [SerializeField]
    AlienEnemy _alienEnemy;
    [SerializeField]
    PersecutionAlien _persecutionAlien;
    [SerializeField]
    AlienCannon _alienCannon;
    [SerializeField]
    AlienHardCannon _alienHardCannon;
    [SerializeField]
    KamikazeAttack _kamikaze;
    [SerializeField]
    KamikazeCannon _kamikazeCannon;
    [SerializeField]
    MotherShip _motherShip;
    [SerializeField]
    MotherShipCannon[] _motherShipCannons;
    [SerializeField]
    DropBombCannon _dropBombCannon;
    [SerializeField]
    DropBomb _dropBomb;
    [SerializeField]
    BossMovment _boss;
    [SerializeField]
    DropBombCannon _bossCannon;

    private void Start()
    {
            switch (_typeOfEnemie)
            {
                case (_enemyType.Alien):
                if (_alienEnemy == null)
                {
                    _alienEnemy = GetComponent<AlienEnemy>();
                }
                if (_persecutionAlien == null)
                {
                    _persecutionAlien = GetComponent<PersecutionAlien>();
                }
                if (_alienCannon == null)
                {
                    _alienCannon = GetComponentInChildren<AlienCannon>();
                }
                if (_alienHardCannon == null)
                {
                    _alienHardCannon = GetComponentInChildren<AlienHardCannon>();
                }
                    break;
                case (_enemyType.Kamikaze):
                if (_kamikaze == null)
                {
                    _kamikaze = GetComponent<KamikazeAttack>();
                }
                if (_kamikazeCannon == null)
                {
                    _kamikazeCannon = GetComponent<KamikazeCannon>();
                }
                break;
                case (_enemyType.MotherShip):
                if (_motherShip == null)
                {
                    _motherShip = GetComponent<MotherShip>();
                }
                    _motherShipCannons = GetComponentsInChildren<MotherShipCannon>();
                    break;
                case (_enemyType.DropBomb):
                if (_dropBombCannon == null)
                {
                    _dropBombCannon = GetComponentInChildren<DropBombCannon>();
                }
                if (_dropBomb == null)
                {
                    _dropBomb = GetComponent<DropBomb>();
                }
                    break;
                case (_enemyType.Boss):
                if (_boss == null)
                {
                    _boss = GetComponent<BossMovment>();
                }
                    break;
            }
        SetNewDifficulty((int)_startDifficulty._currentDificult);
    }
    public void SetNewDifficulty(int _newDifficulty)
    {
        switch (_typeOfEnemie)
        {
            case (_enemyType.Alien):
                switch(_newDifficulty)
                {
                    case (0):
                        _alienEnemy.enabled = true;
                        _persecutionAlien.enabled = false;
                        _alienCannon.enabled = true;
                        _alienHardCannon.enabled = false;
                        break;
                    case (1):
                        _alienEnemy.enabled = false;
                        _persecutionAlien.enabled = true;
                        _alienCannon.enabled = true;
                        _alienHardCannon.enabled = false;
                        break;
                    case (2):
                        _alienEnemy.enabled = false;
                        _persecutionAlien.enabled = true;
                        _alienCannon.enabled = false;
                        _alienHardCannon.enabled = true;
                        break;

                }
                break;
            case (_enemyType.Kamikaze):
                switch (_newDifficulty)
                {
                    case (0):
                        _kamikaze._isNormalOrMore = false;
                        _kamikazeCannon.enabled = false;
                        break;
                    case (1):
                        _kamikaze._isNormalOrMore = true;
                        _kamikazeCannon.enabled = false;
                        break;
                    case (2):
                        _kamikazeCannon.enabled = true;
                        _kamikaze._isNormalOrMore = true;
                        break;

                }
                break;
            case (_enemyType.MotherShip):
                switch (_newDifficulty)
                {
                    case (0):
                        for (int count = _constZero; count < _motherShipCannons.Length; count++)
                        {
                            _motherShipCannons[count].gameObject.SetActive(false);
                        }
                        _motherShip._isHard = false;
                        break;
                    case (1):
                        for(int count = _constZero; count < _motherShipCannons.Length; count++)
                        {
                            _motherShipCannons[count].gameObject.SetActive(true);
                        }
                        _motherShip._isHard = false;
                        break;
                    case (2):
                        for (int count = _constZero; count < _motherShipCannons.Length; count++)
                        {
                            _motherShipCannons[count].gameObject.SetActive(true);
                        }
                        _motherShip._isHard = true;
                        break;
                }
                break;
            case (_enemyType.DropBomb):
                switch (_newDifficulty)
                {
                    case (0):
                        _dropBombCannon.SetDifficulty(_newDifficulty);
                        _dropBombCannon.gameObject.SetActive(false);
                        _dropBomb._isHard = false;
                        break;
                    case (1):
                        _dropBombCannon.SetDifficulty(_newDifficulty);
                        _dropBombCannon.gameObject.SetActive(true);
                        _dropBomb._isHard = false;
                        break;
                    case (2):
                        _dropBombCannon.SetDifficulty(_newDifficulty);
                        _dropBombCannon.gameObject.SetActive(true);
                        _dropBomb._isHard = true;
                        break;
                }
                break;
            case (_enemyType.Boss):
                _boss.SetDifficulty(_newDifficulty);
                break;
            case (_enemyType.DropBombCannon):
                _bossCannon.SetDifficulty(_newDifficulty);
                break;
        }
    }

}
