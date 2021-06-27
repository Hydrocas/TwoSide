using Com.Hugo.Teyssier.Common.CustomBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] protected int maxGrowthLevel = 3;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private Sprite[] growthSprites = null;
    [SerializeField] private Sprite deathSprite = null;

    protected int growthLevel = -1;
    private bool isDead = false;

    public virtual void Grow()
    {
        if (growthLevel == maxGrowthLevel) return;

        growthLevel++;
        spriteRenderer.sprite = growthSprites[growthLevel];
    }

    public void Die()
    {
        growthLevel = -1;
        spriteRenderer.sprite = deathSprite;
        isDead = true;
    }
}
