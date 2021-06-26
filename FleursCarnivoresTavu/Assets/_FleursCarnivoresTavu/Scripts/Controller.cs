using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const int MOUSE_BUTTON = 0;
    private Camera mainCamera;
    private bool isInit;

    public void Init(Camera mainCamera)
    {
        isInit = true;
        this.mainCamera = mainCamera;
    }

    private void Update()
    {
        if (!isInit || !Input.GetMouseButtonUp(MOUSE_BUTTON)) return;

        Ray inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        
    }
}
