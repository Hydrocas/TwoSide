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
}
