using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractButton : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Inventory inventory;
    private StorageBin storageBin;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // When E is pressed
        {
            float interactRadius = .5f;
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius); // Create a detection radius around player
            foreach (Collider2D collider2D in collider2DArray) //Check what objects are around player
            {
                StorageBin storageBin = collider2D.GetComponent<StorageBin>();
                if(storageBin != null) // Checks if is in range of bins
                {
                    storageBin.SpawnItem(); // Calls bin item spawn method
                }
            }  
        }
    }
}
