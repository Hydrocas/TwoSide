using Com.Hugo.Teyssier.Common.CustomBase;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : StateMonoBehaviour
{
    [SerializeField] private Vector2 spawnTimeRange = new Vector2(0.1f, 0.8f);
    [SerializeField] private Bug bugPrefab = null;
    private DayCycleManager dayCycleManager;
    private List<BugSpawnData> currentBugsToSpawn;
    private List<Bug> bugs;

    private void Awake()
    {
        SetModeVoid();
    }

    private void Update()
    {
        DoAction?.Invoke();
    }

    public void Init(DayCycleManager dayCycleManager)
    {
        this.dayCycleManager = dayCycleManager;
        currentBugsToSpawn = new List<BugSpawnData>();
        bugs = new List<Bug>();
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

    public void SetModeDay()
    {
        currentBugsToSpawn.Sort(SortSpawnByEarlier);
        SetModeNormal();
    }

    public void SetModeNight()
    {
        for (int i = bugs.Count - 1; i >= 0; i--)
        {
            bugs[i].Disapear();
        }

        bugs.Clear();
        currentBugsToSpawn.Clear();
        SetModeVoid();
    }

    protected override void DoActionNormal()
    {
        if (currentBugsToSpawn.Count == 0) return;

        if(dayCycleManager.DayProgress >= currentBugsToSpawn[0].spawnDelay)
        {
            SpawnBug(currentBugsToSpawn[0].bugData, currentBugsToSpawn[0].flower);
            currentBugsToSpawn.RemoveAt(0);
        }
    }

    private static int SortSpawnByEarlier(BugSpawnData bugSpawn1, BugSpawnData bugSpawn2)
    {
        if (bugSpawn1.spawnDelay > bugSpawn2.spawnDelay)
            return 1;

        if (bugSpawn1.spawnDelay < bugSpawn2.spawnDelay)
            return -1;

        return 0;
    }

    private void SpawnBug(BugData bugData, Flower flower)
    {
        Bug bug = Instantiate(bugPrefab, (flower.transform.position + Vector3.up), Quaternion.identity);
        bug.Init(bugData);
        bugs.Add(bug);
        bug.OnCollected += Bug_OnCollected;

        Debug.Log("Spawn " + bugData.Type + " bug");
    }

    private void Bug_OnCollected(Bug bug)
    {
        bugs.Remove(bug);
    }
}
