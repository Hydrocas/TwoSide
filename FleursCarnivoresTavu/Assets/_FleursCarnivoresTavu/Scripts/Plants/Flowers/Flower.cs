using System;
using UnityEngine;

public class Flower : Plant
{
    [SerializeField] private BugStack givenBugs = default;
    [SerializeField] private int spawnBugLevel = 2;

    public BugStack GivenBugs => givenBugs;

    public event Action<Flower> OnGiveBugs;

    private void Awake()
    {
        SetModeVoid();
    }

    public void SetDayMode()
    {
        SetModeNormal();

        if(growthLevel >= spawnBugLevel)
        {
            OnGiveBugs?.Invoke(this);
        }
    }

    public void SetNightMode()
    {
        SetModeVoid();
    }

    private void Update()
    {
        DoAction();
    }
}
