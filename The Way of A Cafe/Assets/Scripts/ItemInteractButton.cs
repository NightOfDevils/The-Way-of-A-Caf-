using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractButton : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Inventory inventory;
    [SerializeField] private UI_Inventory ui;
    private StorageBin storageBin;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // When E is pressed
        {
            
            float interactRadius = .5f; // Radius of interaction circle
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius); // Create a detection radius around player
            foreach (Collider2D collider2D in collider2DArray) //Check what objects are around player
            {
                StorageBin storageBin = collider2D.GetComponent<StorageBin>(); // Sets storage bin to the current storage bin player collids with
                if (storageBin != null) // Checks if is in range of bins
                {
                    if(ui.Total() < 4 || storageBin.ItemStackable()) // Checks if inventory has space or the item that wants to be spawned is stackable
                    {
                        storageBin.SpawnItem(); // Calls bin item spawn method
                    }
                    else
                    {
                        Debug.Log("Inventory is Full");
                    }
                }
            }
        }
    }
}
