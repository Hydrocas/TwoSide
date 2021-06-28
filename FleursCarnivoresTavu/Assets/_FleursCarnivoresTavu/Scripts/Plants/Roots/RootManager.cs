using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    private List<Root> roots = null;

    public void Init()
    {
        roots = new List<Root>();
    }

    public void AddRoot(Root root, Flower flower)
    {
        roots.Add(root);
        root.Init(flower);
    }

    public void SetModeDay()
    {
        for (int i = 0; i < roots.Count; i++)
        {
            roots[i].SetDayMode();
        }
    }

    public void SetModeNight()
    {
        for (int i = 0; i < roots.Count; i++)
        {
            roots[i].SetNightMode();
        }
    }
}
