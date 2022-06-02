using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;

    
    private void Start()
    {
        ItemWorld.SpawnItemWorld(transform.position, item);
        //ItemWorld.SpawnItemWorld(new Vector3(2, 2), new Item { itemType = Item.ItemType.Drink, amount = 1 });
        Destroy(gameObject);
    }
}
