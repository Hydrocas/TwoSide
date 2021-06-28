using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public event Action<Seed> OnCollected; 
    private SeedData seedData;

    public void Init(SeedData seedData)
    {
        this.seedData = seedData;
        GetComponent<SpriteRenderer>().sprite = seedData.sprite;
    }

    public SeedData Collect()
    {
        OnCollected?.Invoke(this);
        Destroy(gameObject);
        return seedData;
    }
}
