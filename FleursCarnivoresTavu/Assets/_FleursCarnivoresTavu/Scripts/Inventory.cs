using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private SeedInventory[] seedInventory;
    [SerializeField] private BugInventory[] bugInventory;

    private int seedIndex;
    private int bugIndex;


    public void SetCurrentSeed(int currentSeed)
    {
       // if (!(seedInventory[currentSeed].inventoryAmount > 0))

        seedIndex = currentSeed;
        //Debug.Log(seedIndex);
    }

    public void SetCurrentBug(int currentBug)
    {
        //if (!(bugInventory[currentBug].inventoryAmount > 0)) return ;

        bugIndex = currentBug;
        
    }

    public SeedInventory CurrentSeed => seedInventory[seedIndex];
    public BugInventory CurrentBug => bugInventory[bugIndex];

    //public GameObject SelectedFlower()
    //{
    //    GameObject selectedFlower = null;
    //    return selectedFlower;
    //}

    public void AddSeed(int seedIndex)
    {
        seedInventory[seedIndex].inventoryAmount += 1;
        Debug.Log(seedInventory[seedIndex].inventoryAmount);
    }

    public void RemoveSeed(SeedInventory currentSeed)
    {
        if ((currentSeed.inventoryAmount > 0))
        {
            currentSeed.inventoryAmount -= 1;
            Debug.Log(currentSeed.inventoryAmount);
        }

    }
}
