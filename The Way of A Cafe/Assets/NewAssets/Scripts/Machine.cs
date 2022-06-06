using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineObject machineObject;

    public int GetMachineType()
    {
        return machineObject.machineType;
    }
}
