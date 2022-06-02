using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;
    private Item item;

    private void Start()
    {
        inventory = new Inventory(UseItem); // Sets up new inventory
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory); // Sends new inventory to UI

        /*
         *Ways to spawn items via manual rather than placing in hirearchy 
        ItemWorld.SpawnItemWorld(new Vector3(2, 2), new Item { itemType = Item.ItemType.Drink, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, 2), new Item { itemType = Item.ItemType.Food, amount = 1 });
        */
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>(); // Gets the collider of the item

        if(itemWorld !=null) // Checks if item is in range
        {
            item = itemWorld.GetItem(); // Set item to the current item that was collided with
            if(uiInventory.Total() < 4 || item.IsStackable()) // Check if either inventory has space or if the item is stackable
            {
                inventory.AddItem(itemWorld.GetItem()); //Adds item to list
                itemWorld.DestorySelf(); // Destroys item
            }
            else
            {
                Debug.Log("Inventory is Full");
            }
        }

    }

    private void UseItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.Drink:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Drink, amount = 1 });
                break;
            case Item.ItemType.Food:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Food, amount = 1});
                break;
            case Item.ItemType.CoffeeBeans:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.CoffeeBeans, amount = 1 });
                break;
            case Item.ItemType.EmptyCup:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.EmptyCup, amount = 1 });
                break;
        }
    }

}
