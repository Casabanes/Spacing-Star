using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShot : MonoBehaviour
{

    public Vector3 _dir;
    public CircleCollider2D _cc;
    public Rigidbody2D _rb;
    public float _speed;
    public float _currentTime;
    public float _maxTime;
    const int _constZero = 0;
    const int _constOne = 1;
    public AudioClip _collisionSound;
    public ParticleSystem _ps;
    public Vector3 _scaleExplosion;
    public int _damage;
    public int[] _layerEnemy;
    public AudioSource _audioSource;
    public SpriteRenderer _spriteRenderer;



    public bool _isHard;
    float newPosY;
    float newPosX;


    void Start()
    {
        if (_audioSource == null)
         _audioSource = GetComponent<AudioSource>();
        if(_spriteRenderer==null)
            _spriteRenderer= GetComponent<SpriteRenderer>();

        _cc = GetComponent<CircleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        if (!_isHard)
        {
        _rb.velocity = transform.up * _speed;
        }
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
        {
            if (_isHard)
            {
            Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        if(_cc.enabled==false &&_audioSource.isPlaying==false)
        {
            if (_isHard)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        if (_isHard)
        {
             newPosY = transform.localPosition.y + _speed * Time.deltaTime;
             newPosX = Mathf.Sin(1* newPosY);
            transform.localPosition = new Vector3(newPosX, newPosY, 0);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            for (int count = _constZero; count < _layerEnemy.Length; count++)
            {
                if (collision.gameObject.layer == _layerEnemy[count])
                {
                    if (collision.gameObject.GetComponent<IsDamageable>() == true)
                    {
                        collision.gameObject.GetComponent<IsDamageable>().TakeDamage(_damage);
                        _ps.transform.localScale = _scaleExplosion;
                        _ps.GetComponent<AudioSource>().clip = _collisionSound;
                        Instantiate(_ps, transform.position, _ps.transform.rotation);
                        _cc.enabled = false;
                        _spriteRenderer.enabled = false;
                        _rb.Sleep();
                    }
                    if (collision.gameObject.GetComponent<SimpleIsDamageable>() == true)
                    {
                        collision.gameObject.GetComponent<SimpleIsDamageable>().TakeDamage(_damage);
                        _ps.transform.localScale = _scaleExplosion;
                        _ps.GetComponent<AudioSource>().clip = _collisionSound;
                        Instantiate(_ps, transform.position, _ps.transform.rotation);
                        _cc.enabled = false;
                        _spriteRenderer.enabled = false;
                        _rb.Sleep();
                    }
                }
            }

        }
    }
}

