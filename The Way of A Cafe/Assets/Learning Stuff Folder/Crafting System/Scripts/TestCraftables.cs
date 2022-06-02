using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCraftables : MonoBehaviour
{
    //[SerializeField] private Player player;
    //[SerializeField] private UI_Inventory uiInventory;

    private void Start()
    {
        //uiInventory.SetPlayer(player);
        //uiInventory.SetInventory(player.GetInventory());

        CraftingSystem craftingSystem = new CraftingSystem();
        Item item = new Item { itemType = Item.ItemType.EmptyCup, amount = 1 };
        craftingSystem.SetItem(item, 0, 0);
        Debug.Log(craftingSystem.GetItem(0, 0));
    }
}
