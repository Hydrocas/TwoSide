using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Garden garden = null;
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private BugManager bugManager = null;

    private DayCycleManager dayCycleManager;
    private Inventory inventory;
    private Controller controller;
    private RootManager rootManager;
    private FlowerManager flowerManager;


    private void Awake()
    {
        dayCycleManager = GetComponent<DayCycleManager>();
        inventory = GetComponent<Inventory>();
        controller = GetComponent<Controller>();
        rootManager = GetComponent<RootManager>();
        flowerManager = GetComponent<FlowerManager>();

        controller.Init(mainCamera);
        garden.Init();
        flowerManager.Init(bugManager);
        rootManager.Init();
        bugManager.Init(dayCycleManager);
        dayCycleManager.Init();

        dayCycleManager.OnDay += DayCycleManager_OnDay;
        dayCycleManager.OnNight += DayCycleManager_OnNight;
    }

    private void DayCycleManager_OnNight()
    {
        flowerManager.SetNightMode();
        bugManager.SetModeNight();
        
    }

    private void DayCycleManager_OnDay()
    {
        
        flowerManager.SetDayMode();
        bugManager.SetModeDay();
        
    }

    public void RayHit(RaycastHit rayHit)
    {
        if (rayHit.collider.CompareTag("Garden") && !dayCycleManager.isNight) // If Player clicked garden during day
        {
            SpawnPlants(rayHit.point, inventory.CurrentSeed);
        }
        else if(rayHit.collider.CompareTag("Root") && dayCycleManager.isNight)
        {
            Root root = rayHit.collider.GetComponent<Root>();

            if (root == null) return;

            root.Feed();
            root.Grow();
        }
    }

    private void SpawnPlants(Vector3 spawnPos, SeedInventory seedData)
    {
        Flower flower = Instantiate(seedData.SeedData.flower, spawnPos, Quaternion.identity, garden.GardenGround.transform);
        spawnPos.y -= garden.Height;
        Root root = Instantiate(seedData.SeedData.root, spawnPos, Quaternion.AngleAxis(180, Vector3.forward), garden.GardenGround.transform);

        flowerManager.AddFlower(flower);
        rootManager.AddRoot(root, flower);
    }
}
