using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Dificult_Manager",menuName ="Dificult")]
public class Dificult_Selector : ScriptableObject
{
    public enum _dificult
    {
        Easy=0,Normal=1,Hard=2
    };
    public _dificult _currentDificult = _dificult.Normal;
    

    public void SelectEasy()
    {
        _currentDificult = _dificult.Easy;
    }
    public void SelectNormal()
    {
        _currentDificult = _dificult.Normal;
    }
    public void SelectHard()
    {
        _currentDificult = _dificult.Hard;
    }
}
