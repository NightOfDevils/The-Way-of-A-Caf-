using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public ClickDrag clickDrag;
    public Slot slot;
    public Slot[] inventorySlots; // array of crafting slots
    public List<ItemObject> itemList; // list of items
 

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (clickDrag.WhichSlots() == "CraftingSlot")
            {
                itemList[clickDrag.GetIndex()] = clickDrag.GetItem();
            }

            foreach (Slot slot in inventorySlots)
            {
                RectTransform slotTransform = slot.GetComponent<RectTransform>();
                RectTransform assetTransform = slotTransform.Find("Assets").GetComponent<RectTransform>();
                TextMeshProUGUI itemText = assetTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
                if (slot.item == null)
                {
                    itemList[slot.index] = null;
                }
                else if (slot.item != null)
                {
                    if (slot.itemAmount == 1)
                    {
                        itemText.SetText("");
                    }
                    else
                    {
                        itemText.SetText(slot.itemAmount.ToString());
                    }
                    itemList[slot.index] = slot.item;
                }
            }
        }

        foreach(Slot slot in inventorySlots)
        {
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            RectTransform assetTransform = slotTransform.Find("Assets").GetComponent<RectTransform>();
            TextMeshProUGUI itemText = assetTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
            if (slot.itemAmount == 1)
            {
                itemText.SetText("");
            }
            else
            {
                itemText.SetText(slot.itemAmount.ToString());
            }
        }
    }
}
