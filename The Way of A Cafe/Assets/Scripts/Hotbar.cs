using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{

    private Transform HotBarSelection;
    private Transform itemSlotContainer;

    [SerializeField] private UI_Inventory uiInventory;

    public int x = 0;
    public int y = 0;
    float itemSlotCellSize = 100f;

    public void Awake()
    {
        HotBarSelection = transform.Find("HotBarSelection");
    }

    public void SelectItem(int selection)
    {
        x = selection;
        
        transform.position = transform.position + new Vector3(x * itemSlotCellSize, y * itemSlotCellSize); //Moves object to correct position
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem(3);
        }
    }
}
