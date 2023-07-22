using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPointer : MonoBehaviour
{
    public float _xOffset;
    public float _yOffset;
    void Start()
    {
        Cursor.visible = false;

    }
    void Update()
    {
        transform.position= Camera.main.WorldToScreenPoint(new Vector3(Input.mousePosition.x - _xOffset, Input.mousePosition.y - _yOffset, -Camera.main.transform.position.z));
    }
}
