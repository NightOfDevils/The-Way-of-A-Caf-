using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Machine Object", menuName = "Machine Object")]
public class MachineObject : ScriptableObject
{
    public new string name;
    public int machineType;
    public int machineTime;
    public Sprite image;
}
