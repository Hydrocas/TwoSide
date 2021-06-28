using System;
using UnityEngine;

public class Flower : Plant
{
    [SerializeField] private BugStack givenBugs = default;
    [SerializeField] private SeedData givenSeed = default;
    [SerializeField] private int spawnBugLevel = 2;
    [SerializeField] private Seed seedPrefab = null;
    [SerializeField] private float spawnSeedRate = 2f;
    private bool isDay;
    private bool isSeedSpawned;

    public BugStack GivenBugs => givenBugs;

    public event Action<Flower> OnGiveBugs;
    private Animator animator;
    private float elapsedTime;

    private bool hasFruit;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override bool Grow()
    {
        if(!base.Grow()) return false;

        animator.SetInteger("growthLevel", growthLevel);

        return true;
    }

    public void Init()
    {
        isDay = true;
    }

    public void SetDayMode()
    {
        isDay = true;

        if (growthLevel >= spawnBugLevel)
        {
            OnGiveBugs?.Invoke(this);
        }
    }

    public void SetNightMode()
    {
        isDay = false;
    }

    public SeedData GetSeed()
    {
        if (!hasFruit) return null;

        return givenSeed;
    }

    private void Update()
    {
        if(isDay && growthLevel == maxGrowthLevel && !isSeedSpawned)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime <= spawnSeedRate) return;

            elapsedTime -= spawnSeedRate;
            Seed seed = Instantiate(seedPrefab, transform);
            seed.transform.localPosition = new Vector3(0, 0.3f, -0.1f);
            seed.Init(givenSeed);
            isSeedSpawned = true;
            seed.OnCollected += Seed_Collected;
        }
    }

    private void Seed_Collected(Seed seed)
    {
        isSeedSpawned = false;
    }
}
