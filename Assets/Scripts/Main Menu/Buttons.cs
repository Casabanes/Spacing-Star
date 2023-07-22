using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject _logo;
    [SerializeField]
    private GameObject _playButton;
    [SerializeField]
    private GameObject _howToPlayButton;
    [SerializeField]
    private GameObject _creditsButton;
    [SerializeField]
    private GameObject _exitButton;
    [SerializeField]
    private Dificult_Selector _dificultSelector;
    [SerializeField]
    private GameObject _easyButton;
    [SerializeField]
    private GameObject _normalButton;
    [SerializeField]
    private GameObject _hardButton;
    [SerializeField]
    private GameObject _goBackButton;
    [SerializeField]
    private GameObject _selectDifficultyText;
    [SerializeField]
    private GameObject _changeDifficultyButton;
    [SerializeField]
    private Pause _pause;
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _mainMenuButton;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private CurrentDifficulty _difficultyInScene;
    [SerializeField]
    private GameObject _selectDifficultyPanel;
    [SerializeField]
    private GameObject _mainMenuPanel;
    [SerializeField]
    private TransitionSceneChange _transitionSceneChange;
    [SerializeField]
    private int _firstLevelSceneNumber;
    [SerializeField]
    private int _howToPlaySceneNumber;
    [SerializeField]
    private int _creditsSceneNumber;
    [SerializeField]
    private int _mainMenuSceneNumber;
    private const int _constOne=1;
    [SerializeField]
    private TutorialInstructions _tutorialInstructions;
    [SerializeField]
    private Button _thisButton;
    private int _timesPushed;
    public void Exit()
    {
        Application.Quit();
    }
    public void HowToPlay()
    {
        _transitionSceneChange.ChangeScene(_howToPlaySceneNumber);
    }
    public void Credits()
    {
        _transitionSceneChange.ChangeScene(_creditsSceneNumber);
    }
    public void Play()
    {
        _selectDifficultyPanel.SetActive(true);
        SetMainMenuOnOff(false);
    }
    public void SetMainMenuOnOff(bool onOff)
    {
        _logo.SetActive(onOff);
        _playButton.SetActive(onOff);
        _howToPlayButton.SetActive(onOff);
        _creditsButton.SetActive(onOff);
        _exitButton.SetActive(onOff);
        _mainMenuPanel.SetActive(onOff);
    }
    public void GoBack()
    {
        _selectDifficultyPanel.SetActive(false);
        SetMainMenuOnOff(true);
    }
    public void MainMenu()
    {
        if (_pause != null)
        {
            _pause.ResumeGame();
        }
        _transitionSceneChange.ChangeScene(_mainMenuSceneNumber);
    }
    public void ContinueTutorial()
    {

        if (_thisButton != null)
        {
            _thisButton.interactable = false;
        }
        _tutorialInstructions.QuitMessage();
    }
    public void RestartLevel()
    {
        _transitionSceneChange.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
            _transitionSceneChange.ChangeScene(SceneManager.GetActiveScene().buildIndex+_constOne);
    }
    public void SelectEasy()
    {
        _dificultSelector.SelectEasy();
        _transitionSceneChange.ChangeScene(_firstLevelSceneNumber);
    }
    public void SelectNormal()
    {
        _dificultSelector.SelectNormal();
        _transitionSceneChange.ChangeScene(_firstLevelSceneNumber);
    }
    public void SelectHard()
    {
        _dificultSelector.SelectHard();
        _transitionSceneChange.ChangeScene(_firstLevelSceneNumber);
    }
    public void SelectEasyInGame()
    {
        if (_difficultyInScene != null)
        {
            _dificultSelector.SelectEasy();
            _difficultyInScene.ChangeDifficulty(0);
        }
        GoBackGamePauseMenu();
    }
    public void SelectNormalInGame()
    {
        if (_difficultyInScene != null)
        {
            _dificultSelector.SelectNormal();
            _difficultyInScene.ChangeDifficulty(1);
        }
        GoBackGamePauseMenu();
    }
    public void SelectHardInGame()
    {
        if (_difficultyInScene != null)
        {
            _dificultSelector.SelectHard();
            _difficultyInScene.ChangeDifficulty(2);
        }
        GoBackGamePauseMenu();
    }
    public void ChangeDifficulty()
    {
        _changeDifficultyButton.SetActive(false);
        _resumeButton.SetActive(false);
        _mainMenuButton.SetActive(false);


        _easyButton.SetActive(true);
        _normalButton.SetActive(true);
        _hardButton.SetActive(true);
        _goBackButton.SetActive(true);

    }
    public void GoBackGamePauseMenu()
    {
        _changeDifficultyButton.SetActive(true);
        _resumeButton.SetActive(true);
        _mainMenuButton.SetActive(true);
        _easyButton.SetActive(false);
        _normalButton.SetActive(false);
        _hardButton.SetActive(false);
        _goBackButton.SetActive(false);
    }
    public void ResumeGame()
    {
        _pause.ResumeGame();
    }
    public void Pause()
    {
        _pause.PauseGame();
    }
}
