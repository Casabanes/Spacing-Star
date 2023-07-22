using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    [SerializeField]
    private TutorialInstructions _tutorialInstructions;
    [SerializeField]
    private int _layerToCheck = 9;
    void Start()
    {
        if (_tutorialInstructions == null)
        {
            _tutorialInstructions = FindObjectOfType<TutorialInstructions>();
            if (_tutorialInstructions == null)
            {
                Debug.LogError("No se pudo encontrar el objeto de tipo TutorialInstructions");
                return;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _layerToCheck)
        {
            _tutorialInstructions.HasPassedACheck();
            Destroy(gameObject);
        }
    }
}
