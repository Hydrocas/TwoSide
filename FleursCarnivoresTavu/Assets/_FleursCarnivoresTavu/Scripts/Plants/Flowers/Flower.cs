using System;
using UnityEngine;

public class Flower : Plant
{
    [SerializeField] private BugStack givenBugs = default;
    [SerializeField] private SeedData givenSeed = default;
    [SerializeField] private int spawnBugLevel = 2;
    //[SerializeField] private Sprite[] growthSprites = null;

    public BugStack GivenBugs => givenBugs;

    public event Action<Flower> OnGiveBugs;
    private Animator animator;

    private bool hasFruit;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override bool Grow()
    {
        if(!base.Grow()) return false;

        animator.SetInteger("growthLevel", growthLevel);

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
