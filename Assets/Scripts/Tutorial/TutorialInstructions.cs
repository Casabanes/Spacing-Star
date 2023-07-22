using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialInstructions : MonoBehaviour
{
    private TutorialBrain _tutorialBrain;
    [SerializeField]
    private int _layerEnemy;
    private IsDamageable _isDamageable;
    [SerializeField]
    private RegenerationObject _regenerationObject;
    [SerializeField]
    private OnOffUIBuffAndDebuff _icon;
    private const int _constTwo=2;
    private const int _constOne = 1;
    private const int _constZero = 0;
    private const int _constNinety = 90;
    [SerializeField]
    private string[] _messages;
    [SerializeField]
    private TextMeshProUGUI _messageText;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _showMessageTrigger;
    [SerializeField]
    private string _quitMessageTrigger;
    private int _messagesShowed;
    private bool _isShowingMessage;
    [SerializeField]
    private float _timeToShowTheFirstMessage;

    [SerializeField]
    private float _timeToAllowMovmentAfterShowingAMessage;
    private bool _hasFirstShoted;
    private bool _hasSecondShoted;
    private float _firstShootMode=3;
    private float _secondShootMode=4;
    private float _timeToWaitAfterShotForFirstTime = 2;
    private float _timeToWaitAfterShotForSecondTime = 2;
    [SerializeField]
    private WinLoseManager _winLoseManager;
    private void Start()
    {
        if (_tutorialBrain == null)
        {
            _tutorialBrain = new TutorialBrain();
        }
        _tutorialBrain.SetTutorialInstructions(this);
        _tutorialBrain.SetPlayerMovment(GetComponent<PlayerMovment>());
        _tutorialBrain.SetSecondaryShoot(GetComponent<PlayerSeccondaryShot>());
        _tutorialBrain.SetPlayerTurbo(GetComponent<PlayerTurbo>());
        _tutorialBrain.SetPrimaryShoot(GetComponent<PlayerPrimaryAttack>());
        _isDamageable = GetComponent<IsDamageable>();
        if (_messageText == null)
        {
            Debug.LogError("La variable _messageText no fue asignada");
            return;
        }
        if (_regenerationObject == null)
        {
            Debug.LogError("La variable _regenerationObject no fue asignada");
            return;
        }
        if (_animator == null)
        {
            Debug.LogError("La variable _animator no fue asignada");
            return;
        }
        StartCoroutine(ShowTheFirstMessage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerEnemy)
        {
            if(_isDamageable._life<=_isDamageable._maxLife / _constTwo)
            {
                if (_regenerationObject != null)
                {
                    Instantiate(_regenerationObject, transform.position,transform.rotation);
                    _regenerationObject.SetIcon(_icon);
                }
            }
        }

    }
    public void HasPassedACheck()
    {
        if (!_isShowingMessage)
        {
            _isShowingMessage=true;
            if (_messagesShowed >= _messages.Length)
            {
                Debug.LogError("No hay tantos mensajes, la funcion fue llamada mas de lo que " +
                    "el largo del array permite");
                return;
            }
            else
            {
                ShowMessage(_messages[_messagesShowed]);
            }
        }
    }
    private void ShowMessage(string message)
    {
            _isShowingMessage = true;
            _messageText.text = message;
            _tutorialBrain.SetMode(TutorialBrain.BrainModes.Inactive);
            Cursor.visible = true;
            _animator.SetTrigger(_showMessageTrigger);
    }
    public void QuitMessage()
    {
            Cursor.visible = false;
        _isShowingMessage = false;
            _animator.SetTrigger(_quitMessageTrigger);
            StartCoroutine(ChangeMode());

    }
    public void ThePlayerHasShooted()
    {
        if (_hasFirstShoted)
        {
            return;
        }
        else
        {
            StartCoroutine(WaitForShowTheMessage(_timeToWaitAfterShotForFirstTime));
            _hasFirstShoted = true;
        }
    }
    public void ThePlayerHasHeavyShooted()
    {
        if (_hasSecondShoted)
        {
            return;
        }
        else
        {
            StartCoroutine(WaitForShowTheMessage(_timeToWaitAfterShotForSecondTime));
            _hasSecondShoted = true;
        }
    }
    private IEnumerator ShowTheFirstMessage()
    {
        yield return new WaitForSeconds(_timeToShowTheFirstMessage);
        ShowMessage(_messages[_messagesShowed]);
    }
    private IEnumerator WaitForShowTheMessage(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMessage(_messages[_messagesShowed]);
        transform.rotation = Quaternion.Euler(_constZero, _constZero, -_constNinety);
    }
    private IEnumerator ChangeMode()
    {
        yield return new WaitForSeconds(_timeToAllowMovmentAfterShowingAMessage);
        _messagesShowed++;
        switch (_messagesShowed)
        {
            case (0):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.Inactive);
                break;
            case (1):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.VerticalMovment);
                break;
            case (2):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.HorizontalMovment);
                break;
            case (3):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.PrimaryShot);
                break;
            case (4):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.SeccondaryShot);
                break;
            case (5):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.MovmentAndShots);
                break;
            case (6):
                _tutorialBrain.SetMode(TutorialBrain.BrainModes.AllActions);
                break;
            case (7):
                _winLoseManager.QuitEnemy();
                break;
        }

    }
}
