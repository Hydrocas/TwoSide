using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SeedData[] seedData;

    private int seedIndex;

    public void SetCurrentSeed(int currentSeed)
    {
        seedIndex = currentSeed;
        Debug.Log(seedIndex);
    }
    public SeedData CurrentSeed => seedData[seedIndex];

    public GameObject SelectedFlower()
    {
        GameObject selectedFlower = null;
        return selectedFlower;
    }
}
