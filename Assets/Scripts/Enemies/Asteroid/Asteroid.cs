using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 _dir;
    public Vector3 _rotationAmount;
    public float _speed;
    public float _rotationSpeed;
    Rigidbody2D _rb;
    private AudioSource _audioSource;
    public int[] _layerEnemy;
    const int _constZero = 0;
    public int _damage;
    [SerializeField]
    private bool _useRandomRotation;
    [SerializeField]
    private int _randomRotationMinimalRange;
    [SerializeField]
    private int _randomRotationMaximalRange;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _dir;
        _audioSource = GetComponent<AudioSource>();
        if (_useRandomRotation)
        {
            _rotationAmount = new Vector3(_constZero, _constZero, Random.Range(_randomRotationMinimalRange, _randomRotationMaximalRange));
        }
    }
    private void Update()
    {
        transform.Rotate(_rotationAmount * _rotationSpeed * Time.deltaTime );
    }

    public void OnCollisionEnter2D(Collision2D collision)
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

                    }
                        if (!_audioSource.isPlaying)
                        {
                            _audioSource.Play();
                        }
                }
                
            }
        }
    }
}