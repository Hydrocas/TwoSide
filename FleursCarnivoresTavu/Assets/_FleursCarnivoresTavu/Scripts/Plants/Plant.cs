using Com.Hugo.Teyssier.Common.CustomBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] protected int maxGrowthLevel = 3;
    [SerializeField] private Sprite deathSprite = null;
    [SerializeField] protected SpriteRenderer spriteRenderer = null;

    protected int growthLevel = -1;
    private bool isDead = false;

    public virtual bool Grow()
    {
        if (growthLevel == maxGrowthLevel) return false;

        growthLevel++;

        return true;
    }

    public void Die()
    {
        growthLevel = -1;
        spriteRenderer.sprite = deathSprite;
        isDead = true;
    }
}
