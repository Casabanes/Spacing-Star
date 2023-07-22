using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    private int _playerQuantity;
    private int _enemyQuantity;
    private int _asteroidQuantity;
    private const int _constZero = 0;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _victoryTrigger;
    [SerializeField]
    private string _defeatTrigger;
    [SerializeField]
    private VictoryErrorsPrevent _victoryErrorsPrevent;

    protected virtual void Start()
    {
        if (_victoryErrorsPrevent == null)
        {
            _victoryErrorsPrevent = FindObjectOfType<VictoryErrorsPrevent>();
        }
        if (_animator == null) 
        {
            _animator = GetComponent<Animator>();
        } 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))//estos son los atajos del teclado por si el juego tarda mucho
        {
            for (int i=_enemyQuantity; i > _constZero; i--) 
            {
                QuitEnemy();
            }
        }
        if (Input.GetKeyDown(KeyCode.L)) //estos son los atajos del teclado por si el juego tarda mucho
        {
            QuitPlayer();
        }
    }
    public virtual void AddPlayer() 
    {
        _playerQuantity++;
    }
  public virtual void AddEnemy()
    {
        _enemyQuantity++;
    }
    public virtual void AddAsteroid()
    {
        _asteroidQuantity++;
    }
    public virtual  void QuitAsteroid()
    {
        _asteroidQuantity--;
    }
    public virtual void QuitPlayer()
    {
        _playerQuantity--;
        if (_playerQuantity <= _constZero)
        {
            _animator.SetTrigger("Defeat");
        }
    }
    public virtual void QuitEnemy()
    {
        _enemyQuantity--;
        if (_enemyQuantity <= _constZero)
        {
            _victoryErrorsPrevent.TurnOffProblematicThings();
            _animator.SetTrigger("Victory");
        }
    }
    public virtual void TurnOnTheCursor()
    {
        Cursor.visible = true;
    }
}
