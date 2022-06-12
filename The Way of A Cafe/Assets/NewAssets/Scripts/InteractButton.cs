using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 lastPosition;
    public MachineUI machineUI;
    private bool menuOpen = false;
    public Slot[] inventorySlots;
    private int count = 0;
    private bool dupeFound = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // When E is pressed
        {

            float interactRadius = .1f; // Radius of interaction circle
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius); // Create a detection radius around player

            foreach(Collider2D collider2D in collider2DArray) //Check what objects are around player
            {
                Machine machine = collider2D.GetComponent<Machine>();
                lastPosition = playerTransform.position;
                if (machine != null)
                {
                    if (!menuOpen)
                    {
                        machineUI.openMachineMenu(machine.GetMachineType());
                        menuOpen = true;
                    }
                    else
                    {
                        machineUI.closeMachineMenu(machine.GetMachineType());
                        menuOpen = false;
                    }
                }
            }
            
            foreach(Collider2D collider2D in collider2DArray)
            {
                StorageBin storageBin = collider2D.GetComponent<StorageBin>();
                if (storageBin != null)
                {
                    foreach (Slot slot in inventorySlots)
                    {
                        RectTransform slotTransform = slot.GetComponent<RectTransform>();
                        RectTransform assetTransform = slotTransform.Find("Assets").GetComponent<RectTransform>();
                        Image image = assetTransform.Find("Icon").GetComponent<Image>();
                        TextMeshProUGUI itemText = assetTransform.Find("Amount").GetComponent<TextMeshProUGUI>();

                        foreach(Slot slots in inventorySlots)
                        {
                            if(slots.item == storageBin.ReturnItem())
                            {
                                slots.itemAmount += 1;
                                dupeFound = true;
                                break;
                            }
                        }

                        if (dupeFound)
                        {
                            dupeFound = false;
                            break;
                        }
                        else if (slot.item == null)
                        {
                            assetTransform.gameObject.SetActive(true);
                            slot.item = storageBin.ReturnItem();
                            image.sprite = storageBin.ReturnItem().icon;
                            slot.itemAmount += 1;
                            break;
                        }
                        else if (slot.item != null)
                        {
                            count++;
                            if (count == 4)
                            {
                                Debug.Log("Inventory Full");
                                count = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        if(lastPosition != playerTransform.position)
        {
            float interactRadius = .1f; // Radius of interaction circle
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius); // Create a detection radius around player
            foreach (Collider2D collider2D in collider2DArray) //Check what objects are around player
            {
                Machine machine = collider2D.GetComponent<Machine>();
                if (machine != null)
                {
                    if (menuOpen)
                    {
                        machineUI.closeMachineMenu(machine.GetMachineType());
                        menuOpen = false;
                    }
                }
            }
        }
    }
}
