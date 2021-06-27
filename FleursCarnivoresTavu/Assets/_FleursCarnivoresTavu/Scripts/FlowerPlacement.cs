using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlacement : MonoBehaviour
{
    public LayerMask layerMask;
    Ray _ray;
    RaycastHit _hitData;
    Vector3 _worldPosition;
    Vector3 _mousePos;
    public GameObject MouseCursor;
    public GameObject Flower;
    Vector3 _targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseposition();
        UpdateCursorPosition();
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseRayCast();
            //Debug.Log(_hitData.point);
            if (_targetPosition != Vector3.zero)
            {
                SpawnFlower(_targetPosition);
            }

        }
    }

    private void GetMouseposition()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = Camera.main.nearClipPlane; // Mouse position on near clip plane
        _worldPosition = Camera.main.ScreenToWorldPoint(_mousePos); 
    }
    private void UpdateCursorPosition()
    {
        MouseCursor.transform.position = _worldPosition; // Update Cursor visual
    }
    private void CheckMouseRayCast() // Raycast from mouse position
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitData, 1000, layerMask))
        {
            _targetPosition = _hitData.collider.transform.position; // get hit collider position
        }
    }

    private void SpawnFlower(Vector3 spawnPosition) // Spawn flower on position
    {
        Instantiate(Flower, spawnPosition, Quaternion.identity);
    }
}
