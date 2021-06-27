using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    private List<Flower> flowerList = null;
    private BugManager bugManager;

    public void Init(BugManager bugManager)
    {
        flowerList = new List<Flower>();
        this.bugManager = bugManager;
    }

    public void SpawnFlower(Vector3 spawnPosition, GameObject flower) // Spawn flower on position
    {
        Instantiate(flower, spawnPosition, Quaternion.identity);
    }

    public void AddFlower(Flower flower)
    {
        flowerList.Add(flower);
        flower.OnGiveBugs += Flower_OnGiveBugs;
    }

    private void Flower_OnGiveBugs(Flower flower)
    {
        
    }
}
