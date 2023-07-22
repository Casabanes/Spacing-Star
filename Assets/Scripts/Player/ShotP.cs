using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ShotP : MonoBehaviour
{

    public Vector3 _dir;
    public BoxCollider2D _bc;
    public Rigidbody2D _rb;
    public float _speed;
    public float _currentTime;
    public float _maxTime;
    const int _constZero=0;
    public AudioClip _collisionSound;
    public ParticleSystem _ps;
    public Vector3 _scaleExplosion;
    public SpriteRenderer _sr;
    public int _damage;
    public int[] _layerEnemy;
    public AudioSource _as;

    void Start()
    {
        if (_as == null)
            _as = GetComponent<AudioSource>();
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity =  transform.up*_speed;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
            Destroy(gameObject);
        if(_bc.enabled==false && _as.isPlaying==false )
            Destroy(gameObject);


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            for(int count=_constZero;count  < _layerEnemy.Length; count++)
            {
                if (collision.gameObject.layer == _layerEnemy[count])
                {
                    if (collision.gameObject.GetComponent<IsDamageable>() == true)
                    {
                        collision.gameObject.GetComponent<IsDamageable>().TakeDamage(_damage);
                        _ps.transform.localScale = _scaleExplosion;
                        _ps.GetComponent<AudioSource>().clip = _collisionSound;
                        Instantiate(_ps, transform.position, _ps.transform.rotation);
                        _bc.enabled = false;
                        _sr.enabled = false;
                        _rb.Sleep();
                    }
                    if (collision.gameObject.GetComponent<SimpleIsDamageable>() == true)
                    {
                        collision.gameObject.GetComponent<SimpleIsDamageable>().TakeDamage(_damage);
                        _ps.transform.localScale = _scaleExplosion;
                        _ps.GetComponent<AudioSource>().clip = _collisionSound;
                        Instantiate(_ps, transform.position, _ps.transform.rotation);
                        _bc.enabled = false;
                        _sr.enabled = false;
                        _rb.Sleep();
                    }
                }
            }
        
        }
    }
}
