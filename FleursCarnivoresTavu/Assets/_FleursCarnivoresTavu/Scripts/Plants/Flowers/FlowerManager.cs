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

    public void SetNightMode()
    {
        for (int i = 0; i < flowerList.Count; i++)
        {
            flowerList[i].SetNightMode();
        }
    }

    public void SetDayMode()
    {
        for (int i = 0; i < flowerList.Count; i++)
        {
            flowerList[i].SetDayMode();
        }
    }

    public void AddFlower(Flower flower)
    {
        flower.Init();
        flowerList.Add(flower);
        flower.OnGiveBugs += Flower_OnGiveBugs;
    }

    private void Flower_OnGiveBugs(Flower flower)
    {
        bugManager.AddBugToSpawn(flower);
    }
}
