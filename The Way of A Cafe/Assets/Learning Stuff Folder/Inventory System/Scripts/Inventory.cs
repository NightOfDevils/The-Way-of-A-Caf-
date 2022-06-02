using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
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

    public void RemoveItem(Item item)
    {
        if (item.IsStackable()) //If the item is stackable
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) 
            {
                if (inventoryItem.itemType == item.itemType) 
                {
                    inventoryItem.amount -= item.amount; 
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) 
            {
                itemList.Remove(itemInInventory); 
            }
        }
        else
        {
            itemList.Remove(item); 
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
