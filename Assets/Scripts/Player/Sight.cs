using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float _rotationVelocity;
    const int _constZero = 0;
    public bool _resting;
    private void Start()
    {
        Cursor.visible=false;
    }
    public void Update()
    {
        if (_resting)
            Rest();
    }
    public void Rotation()
    {
        transform.Rotate(Vector3.forward * -_rotationVelocity * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

    }
    public void Rest()
    {
        if (transform.rotation.z != _constZero)
        {

            transform.Rotate(Vector3.forward *_rotationVelocity* +transform.rotation.z * Time.deltaTime);
        }
        else
            return;
    }
   
}
