using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerExtras : MonoBehaviour
{
    const  int _constZero=0;
    public FollowLiveEntity _camera;
    void Start()
    {
        if (FindObjectOfType<AudioListener>() == null)
        {
           _camera= Instantiate(_camera,transform.position,transform.rotation);
        }
        _camera.SetObjetive(transform, new Vector3 (_constZero, _constZero, _constZero));
    }
}
