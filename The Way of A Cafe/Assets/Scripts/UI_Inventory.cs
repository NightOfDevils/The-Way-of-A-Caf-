using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public int x = 0;
    public int y = 0;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public int Total() // Gives the number of slots taken in inventory
    {
        return x;
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        x = 0;
        y = 0;
        float itemSlotCellSize = 100f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>(); //Creates new object
            itemSlotRectTransform.gameObject.SetActive(true); //Sets Object to visible

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize); //Moves object to correct position
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>(); //Chooses correct image of detected item
            image.sprite = item.GetSprite(); //Sets correct image of detected item

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>(); //Set up text changer
            if(item.amount > 1) //Check if amount is more than 1
            {
                uiText.SetText(item.amount.ToString()); //If yes display the amount
            }
            else
            {
                uiText.SetText(""); //If no display no text
            }

            x++; //Shifts potion of new item spawn everything a new item is added
            /*
            if(x > 4)
            {
                x = 0;
                y++;
            }
            */
        }

    }
}
