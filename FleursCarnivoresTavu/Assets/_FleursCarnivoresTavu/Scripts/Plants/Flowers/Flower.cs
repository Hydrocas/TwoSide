using System;
using UnityEngine;

public class Flower : Plant
{
    [SerializeField] private BugStack givenBugs = default;
    [SerializeField] private SeedData givenSeed = default;
    [SerializeField] private int spawnBugLevel = 2;

    public BugStack GivenBugs => givenBugs;

    public event Action<Flower> OnGiveBugs;

    private bool hasFruit;

    public void SetDayMode()
    {
        if(growthLevel >= spawnBugLevel)
        {
            OnGiveBugs?.Invoke(this);
        }
    }

    public void SetNightMode()
    {
        
    }

    public SeedData GetSeed()
    {
        if (!hasFruit) return null;

        return givenSeed;
    }
}
