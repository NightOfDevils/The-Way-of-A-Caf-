using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    [SerializeField] private Transform pfUI_Item;
    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;

    private void Awake()
    {
        Transform gridContainers = transform.Find("gridContainers");

        slotTransformArray = new Transform[CraftingSystem.GRID_SIZE, CraftingSystem.GRID_SIZE];

        for (int i = 0; i < CraftingSystem.GRID_SIZE; i++)
        {
            for (int j = 0; j < CraftingSystem.GRID_SIZE; j++)
            {
                slotTransformArray[i, j] = gridContainers.Find("grid_" + i + "_" + j);
            }
        }
        outputSlotTransform = transform.Find("outputSlot");

        CreateItem(0, 0, new Item { itemType = Item.ItemType.Food, amount = 1});
        //CreateItem(1, 2, new Item { itemType = Item.ItemType.Drink, amount = 1});
        //CreateItemOutput(new Item { itemType = Item.ItemType.Drink, amount = 1});

    }


    private void CreateItem(int x, int y, Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<ItemWorld>().SetItem(item);
    }

    private void CreateItemOutput(Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<ItemWorld>().SetItem(item);
    }
}
