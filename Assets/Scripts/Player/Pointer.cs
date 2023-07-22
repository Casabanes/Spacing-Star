using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float _xOffset;
    public float _yOffset;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x-_xOffset, Input.mousePosition.y - _yOffset, -Camera.main.transform.position.z));
    }
}
