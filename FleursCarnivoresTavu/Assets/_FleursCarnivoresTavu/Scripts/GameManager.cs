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
    }

    public void RayHit(RaycastHit rayHit)
    {
        if (rayHit.collider.CompareTag("Garden") && !dayCycleManager.isNight) // If Player clicked garden during day
        {
            SpawnPlants(rayHit.point, inventory.CurrentSeed);
        }
    }

    private void SpawnPlants(Vector3 spawnPos, SeedData seedData)
    {
        Flower flower = Instantiate(seedData.flower, spawnPos, Quaternion.identity, garden.transform);
        spawnPos.y -= garden.Height;
        Root root = Instantiate(seedData.root, spawnPos, Quaternion.AngleAxis(180, Vector3.forward), garden.transform);

        flowerManager.AddFlower(flower);
        rootManager.AddRoot(root, flower);
    }
}
