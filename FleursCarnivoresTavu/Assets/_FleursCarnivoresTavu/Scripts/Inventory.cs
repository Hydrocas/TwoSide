using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SeedData[] seedData;

    private int seedIndex;

    public SeedData CurrentSeed => seedData[seedIndex];

    public GameObject SelectedFlower()
    {
        GameObject selectedFlower = null;
        return selectedFlower;
    }
}
