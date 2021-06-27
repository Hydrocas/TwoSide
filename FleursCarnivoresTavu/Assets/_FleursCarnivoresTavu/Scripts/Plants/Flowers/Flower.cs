using System;
using UnityEngine;

public class Flower : Plant
{
    [SerializeField] private BugStack givenBugs = default;
    [SerializeField] private SeedData givenSeed = default;
    [SerializeField] private int spawnBugLevel = 2;
    [SerializeField] private Sprite[] growthSprites = null;

    public BugStack GivenBugs => givenBugs;

    public event Action<Flower> OnGiveBugs;

    private bool hasFruit;

    public override bool Grow()
    {
        if(!base.Grow()) return false;

        spriteRenderer.sprite = growthSprites[growthLevel];

        return true;
    }

    public void Init()
    {

    }

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
