using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Plant
{
    [SerializeField] private float[] scaleGrowthLevel;
    private Flower linkedFlower;

    public void Init(Flower linkedFlower)
    {
        this.linkedFlower = linkedFlower;
        Grow();
    }

    public override bool Grow()
    {
        if(!base.Grow()) return false;

        transform.localScale = Vector3.one * scaleGrowthLevel[growthLevel];
        linkedFlower.Grow();

        return true;
    }
}
