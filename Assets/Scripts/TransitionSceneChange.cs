using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionSceneChange : MonoBehaviour
{
    [SerializeField]
    private bool _beginEndingTransition;
    [SerializeField]
    private Animator _animator;
    private int _sceneGoing;
    [SerializeField]
    private Pause _pause;
    [SerializeField]
    private bool _isChanging;
    private const int _constZero = 0;
    private const int _constOne = 1;
    [SerializeField]
    private string _animatorTransitionStateBool;
    private void Start()
    {
        if (_pause == null)
        {
            _pause = FindObjectOfType<Pause>();
        }
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        if (_beginEndingTransition)
        {
            _animator.SetBool(_animatorTransitionStateBool, true);
        }
    }
    public void ChangeScene(int scene)
    {
        if(!_isChanging)
        {
            _sceneGoing = scene;
            _animator.enabled = true;
            _animator.SetBool(_animatorTransitionStateBool, true);
            _isChanging = true;
        }
    }
    private void ChanginghScene()
    {
        if (_sceneGoing > SceneManager.sceneCountInBuildSettings- _constOne)
        {
            _sceneGoing = _constZero;
        }
        SceneManager.LoadScene(_sceneGoing);
    }
    public void IsChangingFalse()
    {
        _isChanging = false;
    }
    public void OffAnimatorBool()
    {
        _animator.SetBool(_animatorTransitionStateBool, false);
    }
}
