using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickDrag : MonoBehaviour
{

    private ItemObject currentItem; // Current Item Held
    private ItemObject sendItem; // Item sent to each manager to set items accordingly
    private bool itemTaken; // Bool to track if product item was taken from crafting
    private int sendIndex; // The index of the slot that obtained an item
    private string whichSlots = ""; // Creates a string that contains the tag of the slot given the item
    public CustomCursor customCursor; // Object of the custom cursor to get it's different values and game object
    public Slot[] allSlots; // Array that contains all slots within the scene (except product slots)
    public CraftingManager craftingManager; // Holds the crafting manager object to access information and functions
    Slot nearestSlot = null; // create a nearest slot variable that holds the closest slot
    Slot swapSlot = null; // creates a slot variable that holds the slot that swaps items with the closests slot

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) // when mouse button is released
        {
            if (currentItem != null) // if the current item exists
            {
                customCursor.gameObject.SetActive(false); // make customcursor invisible
                float shortestDistance = float.MaxValue; // creat a shortest distance variable then set to the absolute max value of a float

                foreach (Slot slot in allSlots) // for each slot in crafting slots
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position); // create distance then set the distance equal to the distance between the mouse and each slot within crafting slot

                    if (dist < shortestDistance) // if the dist of either slot is the smallest
                    {
                        shortestDistance = dist; // set it to the shortest distance
                        nearestSlot = slot; // set the slot as the nearest slot
                    }
                }

                RectTransform slotTransform = nearestSlot.GetComponent<RectTransform>(); // Create a object refering to the rect transform of the nearest slot 
                if (swapSlot == null || currentItem == nearestSlot.item || nearestSlot.item == null) // If there is no item in swap slot or the item held is equal to the nearest slot or the nearest slot has no item
                {
                    if (nearestSlot.item != currentItem) // If the nearest slot item IS NOT equal to the held item
                    {
                        nearestSlot.itemAmount = customCursor.itemAmount; // Sets the nearest slot amount to the amount held in custom cursor
                    }
                    else // If the nearest slot item IS equal to the item held
                    {
                        nearestSlot.itemAmount += customCursor.itemAmount; // Adds the nearest slot amount to the amount held in custom cursor
                    }
                    nearestSlot.item = currentItem; // Sets the nearest slot item to held item
                    nearestSlot.gameObject.SetActive(true); // set the closest crafting slot to visible
                    whichSlots = nearestSlot.gameObject.tag; // Sets which slot to the tag of the nearest slot
                    sendItem = currentItem; // Sets the item sent to the item held
                    sendIndex = nearestSlot.index; // sets the index sent to the index of the nearest slot
                    Image image = slotTransform.Find("Icon").GetComponent<Image>(); // Creates an object refering to the image componenet of the "Icon" game object using the rect transform of the parent object to find it
                    image.sprite = currentItem.icon; // set the sprite of the closest crafting slot to the sprite of the current item held
                    TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>(); // Creates an object refering to the text component of the "Amount" game object using the rect transform of the parent to find it
                    if (nearestSlot.itemAmount == 1) // if the amount of items of the nearest slot is equal to 1
                    {
                        itemText.SetText(""); // Show no number text since icon iteself can represent 1 item
                    }
                    else // if the amount of items of the nearest slot is more than one
                    {
                        itemText.SetText(nearestSlot.itemAmount.ToString()); // Change text to show the amount of items
                    }
                }
                else
                {
                    RectTransform swapSlotTransform = swapSlot.GetComponent<RectTransform>(); // Get the rect transform of the swap slot 
                    swapSlot.item = nearestSlot.item; // sets the item of swapped slot to the item of the nearest slot
                    swapSlot.itemAmount = nearestSlot.itemAmount; // sets the amount of the swapped slot to the amount of the nearest slot
                    swapSlot.gameObject.SetActive(true); // set the closest crafting slot to visible
                    whichSlots = swapSlot.gameObject.tag; // sets the which slot to the swap slot tag
                    sendItem = swapSlot.item; // sets the item sent to the item within the swapped slot
                    sendIndex = swapSlot.index; // sets the index sent to the index of the swapped slot
                    Image swapImage = swapSlotTransform.Find("Icon").GetComponent<Image>(); // Creates an object refering to the image component of the "Icon" game object using the rect transform of the parent objet to find it
                    swapImage.sprite = swapSlot.item.icon; // set the sprite of the closest crafting slot to the sprite of the current item held
                    TextMeshProUGUI swapItemText = swapSlotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();// Creates an object refering to the text component of the "Amount" game object using the rect transform of the parent to find it
                    swapItemText.SetText(swapSlot.itemAmount.ToString());
                    swapSlot = null;

                    if (nearestSlot.item != currentItem)
                    {
                        nearestSlot.itemAmount = customCursor.itemAmount;
                    }
                    else
                    {
                        nearestSlot.itemAmount += customCursor.itemAmount;
                    }
                    nearestSlot.item = currentItem;
                    nearestSlot.gameObject.SetActive(true); // set the closest crafting slot to visible
                    whichSlots = nearestSlot.gameObject.tag; // sets the which slot to the swap slot tag
                    sendItem = currentItem; // sets the item sent to the item held
                    sendIndex = nearestSlot.index; // sets the index send to the index of the nearest slot
                    Image image = slotTransform.Find("Icon").GetComponent<Image>();// Creates an object refering to the image component of the "Icon" game object using the rect transform of the parent objet to find it
                    image.sprite = currentItem.icon; // set the sprite of the closest crafting slot to the sprite of the current item held
                    TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();// Creates an object refering to the text component of the "Amount" game object using the rect transform of the parent to find it
                    if (nearestSlot.itemAmount == 1) // if the amount is equal to 1
                    {
                        itemText.SetText(""); // Show no amount text
                    }
                    else // if amount is greater than 1
                    {
                        itemText.SetText(nearestSlot.itemAmount.ToString()); // show amount text
                    }
                }
                currentItem = null; // set current item to null;
            }
            itemTaken = false; // sets item taken from product to false
        }
    }

    public int GetIndex() // returns the index of a slot
    {
        return sendIndex;
    }

    public ItemObject GetItem() // returns the item of a slot
    {
        return sendItem;
    }

    public string WhichSlots() // returns the which slots string that holds the tag of a slot
    {
        return whichSlots;
    }

    public bool GetItemTaken() // returns the item taken from product bool 
    {
        return itemTaken;
    }

    public void OnMouseDownItem(ItemObject item) //When mouse button is clicked down
    {
        RectTransform itemTransform = customCursor.GetComponent<RectTransform>(); // creates an object of the rect transform of the custom cursor
        if (currentItem == null) // if current item is null
        {
            currentItem = item; // set current item to the item clicked
            customCursor.gameObject.SetActive(true); // set the moveable cursor visible
            Image image = itemTransform.Find("Icon").GetComponent<Image>(); // creates an object reference of the image componenent of the "Icon" game object from the rect transform of custom cursor
            image.sprite = currentItem.icon; // change cursor sprite to item clicked
            customCursor.itemAmount = item.amount; // sets the custom cursor to the item amount 
            TextMeshProUGUI itemText = itemTransform.Find("Amount").GetComponent<TextMeshProUGUI>();// Creates an object refering to the text component of the "Amount" game object using the rect transform of the parent to find it
            if (item.amount == 1)
            {
                itemText.SetText("");
            }
            else
            {
                itemText.SetText(item.amount.ToString());
            }
        }
    }
    public void OnMouseDownSlot(Slot slot) //This function activates after a pointer down event(mouse button click over selected slot) which sets all value within any normal
    {
        RectTransform slotTransform = customCursor.GetComponent<RectTransform>();
        if (currentItem == null) // if current item is null
        {
            currentItem = slot.item; // set current item to the item clicked
            slot.item = null;
            slot.gameObject.SetActive(false);
            customCursor.gameObject.SetActive(true); // set the moveable cursor visible
            Image image = slotTransform.Find("Icon").GetComponent<Image>();
            image.sprite = currentItem.icon; // change cursor sprite to item clicked
            customCursor.itemAmount = slot.itemAmount;
            TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
            if (slot.itemAmount == 1)
            {
                itemText.SetText("");
            }
            else
            {
                itemText.SetText(slot.itemAmount.ToString());
            }
            slot.itemAmount = 0;
            swapSlot = slot; // sets the slot that was taken from as the swap slot for when the player places down an item
        }
    }

    public void OnMouseDownProduct(Slot slot) //This function activates after a pointer down event(mouse button click over the selected slot) which sets all the values within the product slot to the custom cursor to mimic picking up an item from custom cursor
    {
        RectTransform slotTransform = customCursor.GetComponent<RectTransform>();
        if (currentItem == null) // if current item is null
        {
            currentItem = slot.item; // set current item to the item clicked
            slot.item = null;
            slot.gameObject.SetActive(false);
            customCursor.gameObject.SetActive(true); // set the moveable cursor visible
            Image image = slotTransform.Find("Icon").GetComponent<Image>();
            image.sprite = currentItem.icon; // change cursor sprite to item clicked
            customCursor.itemAmount = slot.itemAmount;
            TextMeshProUGUI itemText = slotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
            if (slot.itemAmount == 1)
            {
                itemText.SetText("");
            }
            else
            {
                itemText.SetText(slot.itemAmount.ToString());
            }
            slot.itemAmount = 0;
            itemTaken = true;
            craftingManager.SubItems(1);
        }
    }

}
