using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBin : MonoBehaviour
{
    public Item item;
    [SerializeField] string itemName; // A string field so we can put tags on items to spawn correct items.
    [SerializeField] private Transform playerTransform; // Position of the player

    public void SpawnItem() //Spawns in new item when called upon
    {
        if(itemName == "Drink") // Check if item is drink
        {
            Instantiate(ItemAssets.Instance.ItemWorldSpawner_Drink, playerTransform.position, Quaternion.identity); // Spawn drink item prefab
        }

        if (itemName == "Food") // Check if item is food
        {
            Instantiate(ItemAssets.Instance.ItemWorldSpawner_Food, playerTransform.position, Quaternion.identity); // Spawns food item prefab
        }
    }
}