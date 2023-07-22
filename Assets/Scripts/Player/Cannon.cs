using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Vector3 _dir;
    public AudioListener _camera;
    const int _constZero=0;
    public Animator _an;
    public PlayerPrimaryAttack _player;

    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<AudioListener>();
        if (_an == null)
        {
            _an = GetComponent<Animator>();
        }
        if (_player == null)
        {
            _player = GetComponentInParent<PlayerPrimaryAttack>();
        }
      
    }

    // Update is called once per frame
    void Update()
    {

        _dir = Input.mousePosition;
        _dir = Camera.main.ScreenToWorldPoint(_dir);
        _dir.z = _constZero;
        transform.up = (_dir - transform.position);
        if(!_player._isShotingS)
            _an.SetBool("_isShooting", _player._isShotingS);

    }
    public void Shoot(bool _shoot)
    {
        _an.SetBool("_isShooting", _shoot);
    }
}
