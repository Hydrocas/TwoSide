using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Plant
{
    [SerializeField] private float[] scaleGrowthLevel;
    private Flower linkedFlower;
    private Animator animator;

    public void Init(Flower linkedFlower)
    {
        animator = GetComponent<Animator>();
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

    public void Feed()
    {
        animator.SetTrigger("eat");
    }
}
