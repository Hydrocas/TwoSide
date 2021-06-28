using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SeedInventory
{
    public SeedData SeedData;
    [HideInInspector]
    public int inventoryAmount;
}
