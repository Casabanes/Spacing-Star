using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInstructions : MonoBehaviour
{
    private MainMenuBrain _brain;
    [SerializeField]
    private float _playerDirection;
    [SerializeField]
    private float _timeMoving;
    [SerializeField]
    private float _timeToShoot;
    private const int _constZero = 0;
    [SerializeField]
    private Pointer _pointer;
    [SerializeField]
    private float _timeToActivatePointer;
    private void Start()
    {
        Cursor.visible = false;
        if (_brain == null)
        {
            _brain = new MainMenuBrain { _mainMenuInstructions = this };
        }
        _brain.SetPlayerMovment(GetComponent<PlayerMovment>());
        _brain.SetSecondaryShoot(GetComponent<PlayerSeccondaryShot>());
        _brain.SetPlayerTurbo(GetComponent<PlayerTurbo>());
        _brain.SetDirection(_playerDirection);
        StartCoroutine(Shooting());
        StartCoroutine(Moving());
        if(_timeToShoot == _constZero)
        {
            Debug.LogError("La variable _timeToShoot no fue asignada");
        }
    }
    private IEnumerator Moving()
    {
        Cursor.visible = false;
        _brain.SetBrainMode(MainMenuBrain.BrainMode.Moving);
        yield return new WaitForSeconds(_timeMoving);
    }
    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_timeToShoot);
        _brain.SetBrainMode(MainMenuBrain.BrainMode.Shoting);
        StartCoroutine(ActivatePointer());
    }
    private IEnumerator ActivatePointer()
    {
        yield return new WaitForSeconds(_timeToActivatePointer);
        _pointer.gameObject.SetActive(true);
    }
}
