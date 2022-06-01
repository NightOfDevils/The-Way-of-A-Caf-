using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.Food, amount = 1 });

    }

    public void AddItem(Item item)
    {
        if(item.IsStackable()) //If the item is stackable
        {
            bool itemAlreadyInInventory = false; //Is the item in the inventory?
            foreach(Item inventoryItem in itemList) //Check each item in the inventory
            {
                if(inventoryItem.itemType == item.itemType) //If item is in inventory
                {
                    inventoryItem.amount += item.amount; //Add to amount(stack item)
                    itemAlreadyInInventory = true; //Item is in inventory
                }
            }
            if(!itemAlreadyInInventory) //If item is not in inventory
            {
                itemList.Add(item); // Add item
            }
        }
        else //If item is not stackable
        {
            itemList.Add(item); //Add item
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
