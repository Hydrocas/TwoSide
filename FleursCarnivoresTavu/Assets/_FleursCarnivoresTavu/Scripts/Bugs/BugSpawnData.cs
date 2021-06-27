using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BugSpawnData
{
    public BugData bugData;
    public float spawnDelay;
    public Flower flower;

    public BugSpawnData(BugData bugData, Flower flower, float spawnDelay)
    {
        this.bugData = bugData;
        this.spawnDelay = spawnDelay;
        this.flower = flower;
    }
}
