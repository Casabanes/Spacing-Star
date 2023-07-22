using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    Image _panelImage;
    [SerializeField]
    GameObject _childrenPanelImage;
    [SerializeField]
    GameObject _pauseButton;
    [SerializeField]
    Pointer _pointer;
    [SerializeField]
    private Texture2D _cursorTexture;
    [SerializeField]
    private Vector2 _cursorOffset;
    bool _isPaused;
    const int _constZero = 0;
    const int _constOne = 1;

    private void Start()
    {
        Cursor.SetCursor(_cursorTexture, _cursorOffset,CursorMode.Auto);
        if (_pauseButton == null)
        {
            Debug.LogError("La variable _pauseButton no fue asignada");
            return;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible=true;
        _pauseButton.SetActive(false);
        _isPaused = true;
        Time.timeScale = _constZero;
        _panelImage.enabled = true;
        _childrenPanelImage.SetActive(true);
    }
    public void ResumeGame()
    {
        Cursor.visible = false;
        _pauseButton.SetActive(true);
        _isPaused = false;
        Time.timeScale = _constOne;
        _panelImage.enabled = false;
        _childrenPanelImage.SetActive(false);
    }
}
