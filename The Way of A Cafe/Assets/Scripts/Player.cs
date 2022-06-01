using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void Start()
    {
        inventory = new Inventory(); // Sets up new inventory
        uiInventory.SetInventory(inventory); // Sends new inventory to UI

        /*
         *Ways to spawn items via manual rather than placing in hirearchy 
        ItemWorld.SpawnItemWorld(new Vector3(2, 2), new Item { itemType = Item.ItemType.Drink, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, 2), new Item { itemType = Item.ItemType.Food, amount = 1 });
        */
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>(); // Gets the collider of the item

        if(itemWorld !=null) // Checks if item is in range
        { 
            inventory.AddItem(itemWorld.GetItem()); //Adds item to list
            itemWorld.DestorySelf(); // Destroys item
        }

    }

}
