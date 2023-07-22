using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDifficulty : MonoBehaviour
{
    [SerializeField]
    DifficultyInThisEnemie[] _enemies;
    [SerializeField]
    int _currentDifficulty;
    [SerializeField]
    Dificult_Selector _baseDifficulty;
    private void Start()
    {
        _currentDifficulty = (int)_baseDifficulty._currentDificult;
    }
    public void ChangeDifficulty(int _difficulty)
    {
        if (_difficulty == _currentDifficulty)
        {
            return;
        }

        _enemies=FindObjectsOfType<DifficultyInThisEnemie>();
        for(int count = 0; count < _enemies.Length; count++)
        {
            _currentDifficulty = _difficulty;
            _enemies[count].SetNewDifficulty(_difficulty);
        }
    }

}
