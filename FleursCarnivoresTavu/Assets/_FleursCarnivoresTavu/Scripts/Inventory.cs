using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SeedData[] seedData;
    [SerializeField] private BugData[] bugData;

    private int seedIndex;
    private int bugIndex;

    public void SetCurrentSeed(int currentSeed)
    {
        seedIndex = currentSeed;
        //Debug.Log(seedIndex);
    }

    public void SetCurrentBug(int currentBug)
    {
        bugIndex = currentBug;
        
    }

    public SeedData CurrentSeed => seedData[seedIndex];
    public BugData CurrentBug => bugData[bugIndex];

    public GameObject SelectedFlower()
    {
        GameObject selectedFlower = null;
        return selectedFlower;
    }
}
