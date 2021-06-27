using Com.Hugo.Teyssier.Common.CustomBase;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : StateMonoBehaviour
{
    [SerializeField] private Vector2 spawnTimeRange = new Vector2(0.1f, 0.8f);
    private DayCycleManager dayCycleManager;
    private List<BugSpawnData> currentBugsToSpawn;

    private void Awake()
    {
        SetModeVoid();
    }

    public void Init(DayCycleManager dayCycleManager)
    {
        this.dayCycleManager = dayCycleManager;
    }

    public void AddBugToSpawn(Flower flower)
    {
        BugStack bugStack = flower.GivenBugs;
        BugSpawnData bugSpawnData;

        for (int i = 0; i < bugStack.GivenNumber; i++)
        {
            bugSpawnData = new BugSpawnData(bugStack.BugData, flower, Random.Range(spawnTimeRange.x, spawnTimeRange.y));
            currentBugsToSpawn.Add(bugSpawnData);
        }
    }

    public void SetDayMode()
    {
        currentBugsToSpawn.Sort(SortSpawnByEarlier);
        SetModeNormal();
    }

    public void SetModeNight()
    {
        currentBugsToSpawn.Clear();
        SetModeVoid();
    }

    protected override void DoActionNormal()
    {
        base.DoActionNormal();

        //Spawn Test
    }

    private static int SortSpawnByEarlier(BugSpawnData bugSpawn1, BugSpawnData bugSpawn2)
    {
        if (bugSpawn1.spawnDelay > bugSpawn2.spawnDelay)
            return 1;

        if (bugSpawn1.spawnDelay < bugSpawn2.spawnDelay)
            return -1;

        return 0;
    }
}
