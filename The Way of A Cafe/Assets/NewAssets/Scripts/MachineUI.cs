using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineUI : MonoBehaviour
{

    public CraftingManager craftingManager;
    public MachineUI machineUI;

    public void openMachineMenu(int whichMachine)
    {
        Debug.Log("The gates are open");
        machineUI.gameObject.SetActive(true);
        if(whichMachine == 1)
        {
            craftingManager.gameObject.SetActive(true);
        }
    }

    public void closeMachineMenu(int whichMachine)
    {
        Debug.Log("The gates are closed");
        machineUI.gameObject.SetActive(false);
        if (whichMachine == 1)
        {
            craftingManager.gameObject.SetActive(false);
        }
    }
}
