using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const int MOUSE_BUTTON = 0;
    private Camera mainCamera;
    private bool isInit;
    private Ray inputRay;
    private GameManager gameManager;

    [HideInInspector]
    public RaycastHit rayHit;
    public LayerMask layerMask;

    public void Init(Camera mainCamera)
    {
        isInit = true;
        this.mainCamera = mainCamera;

        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!isInit || !Input.GetMouseButtonUp(MOUSE_BUTTON)) return;

        inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(inputRay.origin, inputRay.direction * 100, Color.red, 1000);


        if (Physics.Raycast(inputRay, out rayHit, 1000, layerMask))
        {
            gameManager.RayHit(rayHit);
        }
    }


}
