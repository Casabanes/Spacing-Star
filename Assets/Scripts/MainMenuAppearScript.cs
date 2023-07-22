using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAppearScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _asteroid;
    [SerializeField]
    private GameObject _mainMenu;
    void Start()
    {
        if (_asteroid == null)
        {
            FindObjectOfType<Asteroid>();
        }
    }
    void Update()
    {
        if (_asteroid == null)
        {
            _mainMenu.SetActive(true);
        }    
    }
}
