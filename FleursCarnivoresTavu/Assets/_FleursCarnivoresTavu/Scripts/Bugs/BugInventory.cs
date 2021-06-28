using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BugInventory
{
    public BugData BugData;
    [HideInInspector]
    public int inventoryAmount;
}
