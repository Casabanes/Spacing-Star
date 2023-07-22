using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OnOffUIBuffAndDebuff : MonoBehaviour
{
    private float _actualTime;
    private int _timeInInt;
    private const int _constZero = 0;
    [SerializeField]
    private TextMeshProUGUI _txt;
    [SerializeField]
    private TypeOfBuffOrDebuff _type;
    private void Update()
    {
        if (_actualTime > _constZero)
        {
            _actualTime -= Time.deltaTime;
            _timeInInt = (int)_actualTime;
            _txt.text = _timeInInt.ToString();
        }
        else
        {
            _actualTime = _constZero;
            gameObject.SetActive(false);
        }
    }
    public void SetOnTimer(float timeOnOff)
    {
        _actualTime += timeOnOff;
        _timeInInt = (int)_actualTime;
        _txt.text = _timeInInt.ToString();
        gameObject.SetActive(true);
    }    
    public enum TypeOfBuffOrDebuff
    {
        SpeedBuff,SpeedDebuf,EnergyDebuff,InFireDebuff,RegenerationBuff,MultiShotBuff
    };
    public TypeOfBuffOrDebuff GetTypeOfBuffOrDebuff()
    {
        return _type;
    }
}
