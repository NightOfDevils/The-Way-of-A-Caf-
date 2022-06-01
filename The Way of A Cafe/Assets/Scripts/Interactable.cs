using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactionAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange)// If in range
        {
            if(Input.GetKeyDown(interactKey))// If key pressed
            {
                interactionAction.Invoke();// Start event
            }
        }

    }
}
