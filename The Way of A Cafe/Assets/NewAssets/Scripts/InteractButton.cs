using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public MachineUI machineUI;
    private Machine machine;
    private bool menuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // When E is pressed
        {

            float interactRadius = .5f; // Radius of interaction circle
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius); // Create a detection radius around player
            foreach (Collider2D collider2D in collider2DArray) //Check what objects are around player
            {
                Machine machine = collider2D.GetComponent<Machine>();
                if(machine != null)
                {
                    if(!menuOpen)
                    {
                        machineUI.openMachineMenu(machine.GetMachineType());
                        menuOpen = true;
                    }
                    else
                    {
                        machineUI.closeMachineMenu(machine.GetMachineType());
                        menuOpen = false;
                    }
                }
            }
        }
    }
}