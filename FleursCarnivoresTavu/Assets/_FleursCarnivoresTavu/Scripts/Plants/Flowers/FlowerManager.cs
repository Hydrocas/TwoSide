using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    private List<Flower> flowerList = null;
    private BugManager bugManager;
    public Flower debugFlower;

    public void Init(BugManager bugManager)
    {
        flowerList = new List<Flower>();
        this.bugManager = bugManager;
    }

    public void SpawnFlower(Vector3 spawnPosition, Flower flowerPrefab) // Spawn flower on position
    {
        Flower lFlower = Instantiate(debugFlower, spawnPosition, Quaternion.identity);
        lFlower.Init();
        AddFlower(lFlower);
    }

    public void AddFlower(Flower flower)
    {
        flowerList.Add(flower);
        flower.OnGiveBugs += Flower_OnGiveBugs;
    }

    private void Flower_OnGiveBugs(Flower flower)
    {
        bugManager.AddBugToSpawn(flower);
    }
}
