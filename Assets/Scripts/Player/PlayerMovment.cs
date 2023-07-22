
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    BaseBrain _brain;
    [SerializeField]
    private bool _theBrainIsCreatedExternaly;

    const int _constZero = 0;
    const int _constOne = 1;

    public Rigidbody2D _rb;


    public float _speed;   //movment variables
    public float _inertiaUmbral;
    public float _inertiaDuration;
    public float _velocityX;
    public float _velocityY;
    public float _speedCap;
    public float _buffSpeed;
    public float _buffSpeedCap;//movment variables

    public float _rotationSpeed; //rotation variables
    public float _rotationVelocity;
    public float _inertiaRUmbral;
    public float _inertiaRDuration;
    public float _speedRCap;     //rotation variables

    public AudioSource _movmentAudioSource;
    public float _minMovmentAudioVolume;
    public float _midMovmentAudioVolume;
    public Animator _animatorController;

    [SerializeField]
    bool _cantMove;

    void Start()
    {
        if (!_theBrainIsCreatedExternaly)
        {
            _brain = new Brain { _playerMovment = this };
        }
        if (_rb == null)
        {
        _rb = GetComponent<Rigidbody2D>();
        }
        if (_animatorController == null)
        {
        _animatorController = GetComponent<Animator>();
        }
    }
    void Update()
    {
        _brain.Listen_Keys();
    }

    public void Movment(float _direction)
    {
        if(_cantMove)
        {
            return;
        }
        if (_direction == _constZero)
        {
            if (_movmentAudioSource.volume > _minMovmentAudioVolume)
                _movmentAudioSource.volume = _minMovmentAudioVolume;
        }
        _velocityX = _direction* transform.up.x * _speed* _buffSpeed;
        _velocityY = _direction* transform.up.y * _speed*_buffSpeed;

        _rb.velocity += new Vector2(_velocityX , _velocityY);

        if (_rb.velocity.x > _speedCap+_buffSpeedCap)                                             //-------------evito que acelere de mas--------------
            _rb.velocity = new Vector2(_speedCap, _rb.velocity.y);
        if (_rb.velocity.x < -(_speedCap + _buffSpeedCap))
            _rb.velocity = new Vector2(-_speedCap, _rb.velocity.y);                 //-------------evito que acelere de mas--------------

        if (_rb.velocity.y > _speedCap + _buffSpeedCap)                                             //-------------evito que acelere de mas--------------
            _rb.velocity = new Vector2(_rb.velocity.x, _speedCap);
        if (_rb.velocity.y < -(_speedCap + _buffSpeedCap))
            _rb.velocity = new Vector2(_rb.velocity.x, -_speedCap);
    }
    public void Rotation(float _rotationDirection)
    {
        if (_rotationDirection == _constZero)                                          //-------------al no acelerar hace lo siguiente-----
        {
            if (_rotationVelocity > _constZero)                                        //-------reduccion de velocidad por inercia---------
                _rotationVelocity -= _rotationVelocity / _inertiaRDuration;
            if (_rotationVelocity < _constZero)
                _rotationVelocity -= _rotationVelocity / _inertiaRDuration;           //reduccion de velocidad por inercia

            if (_rotationVelocity > _constZero && (_rotationVelocity - _rotationVelocity / _inertiaRDuration) < _constZero) //evito que la reduccion de velocidad por inercia acelere al lado opuesto
                _rotationVelocity = _constZero;
            if (_rotationVelocity < _constZero && (_rotationVelocity + _rotationVelocity / _inertiaRDuration) > _constZero)
                _rotationVelocity = _constZero;                                        //evito que la reduccion de velocidad por inercia acelere al lado opuesto

            if (_rotationVelocity < _constZero && _rotationVelocity > -_inertiaRUmbral)          //-------------detencion por poca inercia-----------
                _rotationVelocity = _constZero;
            if (_rotationVelocity > _constZero && _rotationVelocity < _inertiaRUmbral)
                _rotationVelocity = _constZero;                                       //-------------detencion por poca inercia-----------
        }
        _rotationVelocity = _rotationSpeed * _rotationDirection;            //------------aceleracion-------------------------
        transform.Rotate(Vector3.forward * -_rotationVelocity * Time.deltaTime);
        if (_rotationVelocity > _speedRCap)                                             //-------------evito que acelere de mas--------------
            _rotationVelocity = _speedRCap;
        if (_rotationVelocity < -_speedRCap)
            _rotationVelocity = -_speedRCap;                                            //-------------evito que acelere de mas--------------

    }


    public void TurboMode(float _volume,float _speedAux, float _speedCapAux)
    {
        _movmentAudioSource.volume = _volume;
        _speed = _speedAux;
        _speedCap = _speedCapAux;
    }
    public void CallIsPushd(float _timeToMove, Vector2 _v2, float _explotionForce)
    {
        StartCoroutine(IsPushed(_timeToMove, _v2, _explotionForce));
    }
    private IEnumerator IsPushed(float _timeToMove, Vector2 _v2, float _explotionForce)
    {
        _cantMove = true;
        _rb.AddForce(_v2.normalized * _explotionForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_timeToMove);
        _cantMove = false;
    }
    public void SetBrain(BaseBrain brain)
    {
        _brain = brain;
    }
}
