using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldSpawner : MonoBehaviour
{
    [SerializeField]
    private BossShieldRotation _shieldPrefab;
    [SerializeField]
    private BossShieldRotation _actualShield;
    [SerializeField]
    private float _timeToRespawn;
    private const int _constZero = 0;
    void Start()
    {
        if (_shieldPrefab == null)
        {
            Debug.Log("La variable _shieldPrefab no fue asignada, este objeto se destruirá");
            Destroy(this.gameObject);
        }
        if (_timeToRespawn == _constZero)
        {
            Debug.Log("La variable _timeToRespawn no fue asignada");
        }
        StartCoroutine(ShieldSpawn());
    }
    private IEnumerator ShieldSpawn()
    {
        if (_actualShield == null)
        {
            _actualShield = Instantiate(_shieldPrefab);
            _actualShield.transform.parent = transform;
            _actualShield.transform.position = transform.position;
        }
        yield return new WaitForSeconds(_timeToRespawn);
        StartCoroutine(ShieldSpawn());
    }
}
