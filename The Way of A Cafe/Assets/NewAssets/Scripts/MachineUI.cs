using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineUI : MonoBehaviour
{

    public CraftingManager espressoMachine;
    public CraftingManager blenderMachine;
    public MachineUI machineUI;

    public void openMachineMenu(int whichMachine)
    {
        Debug.Log("The gates are open");
        machineUI.gameObject.SetActive(true);
        if(whichMachine == 1)
        {
            espressoMachine.gameObject.SetActive(true);
        }
        else if (whichMachine == 2)
        {
            blenderMachine.gameObject.SetActive(true);
        }
    }

    public void closeMachineMenu(int whichMachine)
    {
        Debug.Log("The gates are closed");
        machineUI.gameObject.SetActive(false);
        if (whichMachine == 1)
        {
            espressoMachine.gameObject.SetActive(false);
        }
        else if (whichMachine == 2)
        {
            blenderMachine.gameObject.SetActive(false);
        }
    }
}
