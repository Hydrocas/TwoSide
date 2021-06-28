using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Garden garden = null;
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private BugManager bugManager = null;
    [SerializeField] private SeedData[] startPlantedSeed = null;

    private DayCycleManager dayCycleManager;
    private Inventory inventory;
    private Controller controller;
    private RootManager rootManager;
    private FlowerManager flowerManager;
    private SoundManager soundManager;


    private void Awake()
    {
        dayCycleManager = GetComponent<DayCycleManager>();
        inventory = GetComponent<Inventory>();
        controller = GetComponent<Controller>();
        rootManager = GetComponent<RootManager>();
        flowerManager = GetComponent<FlowerManager>();
        soundManager = GameObject.FindGameObjectWithTag("MusicManager").gameObject.GetComponent<SoundManager>();

        dayCycleManager.Init();
        controller.Init(mainCamera);
        garden.Init();
        flowerManager.Init(bugManager);
        rootManager.Init();
        bugManager.Init(dayCycleManager);
        

        dayCycleManager.OnDay += DayCycleManager_OnDay;
        dayCycleManager.OnNight += DayCycleManager_OnNight;

        StartSpawn();
    }

    private void DayCycleManager_OnNight()
    {
        flowerManager.SetNightMode();
        rootManager.SetModeNight();
        bugManager.SetModeNight();
        
    }

    private void DayCycleManager_OnDay()
    {
        
        flowerManager.SetDayMode();
        rootManager.SetModeDay();
        bugManager.SetModeDay();
        
    }

    public void RayHit(RaycastHit rayHit)
    {
        if (rayHit.collider.CompareTag("Garden") && !dayCycleManager.isNight) // If Player clicked garden during day
        {
            SeedData seed = inventory.TakeCurrentSeed();

            if (seed == null) return;

            SpawnPlants(rayHit.point, seed);
            soundManager.SeedPlantSound();
        }
        else if(rayHit.collider.CompareTag("Root") && dayCycleManager.isNight)
        {
            Root root = rayHit.collider.GetComponent<Root>();

            if (root == null) return;

            root.Feed();
            root.Grow();
            soundManager.PlantEatSound();
        }
        else if (rayHit.collider.CompareTag("Bug") && !dayCycleManager.isNight)
        {
            Bug bug = rayHit.collider.GetComponent<Bug>();

            if (bug == null) return;

            inventory.AddBug(bug.Collect());
            soundManager.InsectPickSound();
        }
    }

    private void SpawnPlants(Vector3 spawnPos, SeedData seedData)
    {
        Flower flower = Instantiate(seedData.flower, spawnPos, Quaternion.identity, garden.GardenGround.transform);
        spawnPos.y -= garden.Height;
        Root root = Instantiate(seedData.root, spawnPos, Quaternion.AngleAxis(180, Vector3.forward), garden.GardenGround.transform);

        flowerManager.AddFlower(flower);
        rootManager.AddRoot(root, flower);

        
    }

    public void StartSpawn()
    {
        Vector2 randomCircle;
        for (int i = startPlantedSeed.Length - 1; i >= 0; i--)
        {
            randomCircle = UnityEngine.Random.insideUnitCircle * UnityEngine.Random.Range(0f, 5f);

            SpawnPlants(
                Vector3.up * (garden.Height / 2) +
                new Vector3(randomCircle.x, 0, randomCircle.y),
                startPlantedSeed[i]);
        }
    }
}
