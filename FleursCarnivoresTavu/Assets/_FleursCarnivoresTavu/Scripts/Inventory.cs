using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField]public SeedInventory[] seedInventory;
    [SerializeField] private BugInventory[] bugInventory;


    [SerializeField] private TextMeshProUGUI[] UIseedElements;
    [SerializeField] private TextMeshProUGUI[] UIBugElements;


    private int seedIndex = -1;
    private int bugIndex = -1;

    public void Update()
    {
        for (int i = 0; i < seedInventory.Length; i++)
        {
            UIseedElements[i].text = seedInventory[i].inventoryAmount.ToString();
        }

        for (int i = 0; i < bugInventory.Length; i++)
        {
            UIBugElements[i].text = bugInventory[i].inventoryAmount.ToString();
        }
    }

    public SeedInventory CurrentSeed 
    {
        get => seedInventory[seedIndex]; 
        set
        {
            seedInventory[seedIndex] = value;
        }
    }
    public BugInventory CurrentBug 
    {
        get => bugInventory[bugIndex]; 
        set
        {
            bugInventory[bugIndex] = value;
        }
    }

    public void SetCurrentSeed(int currentSeed)
    {
       // if (!(seedInventory[currentSeed].inventoryAmount > 0))

        seedIndex = currentSeed;
        bugIndex = -1;
    }

    public void SetCurrentBug(int currentBug)
    {
        //if (!(bugInventory[currentBug].inventoryAmount > 0)) return ;

        bugIndex = currentBug;
        seedIndex = -1;
    }

    public SeedData TakeCurrentSeed()
    {
        if (seedIndex == -1 || CurrentSeed.inventoryAmount <= 0) return null;

        SeedInventory currentSeed = CurrentSeed;
        currentSeed.inventoryAmount--;
        CurrentSeed = currentSeed;
        return currentSeed.SeedData;
    }

    public BugData TakeCurrentBug()
    {
        if (bugIndex == -1 || CurrentBug.inventoryAmount <= 0) return null;

        BugInventory currentBug = CurrentBug;
        currentBug.inventoryAmount--;
        CurrentBug = currentBug;
        return CurrentBug.BugData;
    }

    public void AddSeed(SeedData seedData)
    {
        for (int i = 0; i < seedInventory.Length; i++)
        {
            if (seedInventory[i].SeedData.type == seedData.type)
            {
                SeedInventory seedIventory = seedInventory[i];
                seedIventory.inventoryAmount++;
                seedInventory[i] = seedIventory;
                return;
            }
        }
    }

    public void AddBug(BugData bugData)
    {
        for (int i = 0; i < bugInventory.Length; i++)
        {
            if (bugInventory[i].BugData.Type == bugData.Type)
            {
                BugInventory bugIventory = bugInventory[i];
                bugIventory.inventoryAmount++;
                bugInventory[i] = bugIventory;
                return;
            }
        }
    }
}
