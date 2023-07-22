using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreMotherShip : MonoBehaviour
{
    public BoxCollider2D _bc;
    void Start()
    {
        if (_bc == null)
            _bc = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Nave Nodriza" || collision.gameObject.name == "Nave Nodriza(Clone)")
        {
            _bc.isTrigger = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Nave Nodriza" || collision.gameObject.name == "Nave Nodriza(Clone)")
        {
            _bc.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _bc.isTrigger = false;
    }
}
