using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        /*
         *Ways to spawn items via manual rather than placing in hirearchy 
        ItemWorld.SpawnItemWorld(new Vector3(2, 2), new Item { itemType = Item.ItemType.Drink, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-2, 2), new Item { itemType = Item.ItemType.Food, amount = 1 });
        */
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if(itemWorld !=null)
        { 
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestorySelf();
        }

    }

}
