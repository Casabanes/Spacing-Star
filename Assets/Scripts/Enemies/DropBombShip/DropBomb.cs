using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public PlayerMovment _player;
    [SerializeField]
    public float _persecutionRange;
    public float _distanceToPlayer;
    public int _damage;
    public Bomb _bomb;
    public Sprite[] _bombSprites;
    public SpriteRenderer _bombSr;
    const int _constZero = 0;
    const int _constOne = 1;
    public float _time;
    public float _timeToSpawnBomb;
    public Transform[] _bombSpawnPositions;
    public float _forceToLaunchBomb;
    private Bomb _actualBomb;
    public bool _isHard;
    void Start()
    {
        _player = FindObjectOfType<PlayerMovment>();
        if (_bombSr == null)
            _bombSr = _bomb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
            _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_persecutionRange > _distanceToPlayer)
        {
            SpawnBomb();
        }
    }
    void SpawnBomb()
    {
        _time += Time.deltaTime;
        if(_time>=_timeToSpawnBomb)
        {
            _bombSr.sprite = _bombSprites[Random.Range(_constZero, _bombSprites.Length- _constOne)];
            _actualBomb=Instantiate(_bomb,_bombSpawnPositions[Random.Range(_constZero, _bombSpawnPositions.Length)].position,transform.rotation);
            _actualBomb._damage = _damage;
            _actualBomb.Impulse(-transform.up, _forceToLaunchBomb);
            if (_isHard)
            {
                _actualBomb._isHard = true;
                _actualBomb._playerMovment = _player;
            }
            _time = _constZero;
        }
    }
}
