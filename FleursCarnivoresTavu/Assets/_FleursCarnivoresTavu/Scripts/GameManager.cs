using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Garden garden = null;
    [SerializeField] private Camera mainCamera = null;

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
    }

    public void RayHit(RaycastHit rayHit)
    {
        if (rayHit.collider.CompareTag("Garden") && !dayCycleManager.isNight) // If Player clicked garden during day
        {
            flowerManager.SpawnFlower(rayHit.point, inventory.SelectedFlower());
        }
    }
}
