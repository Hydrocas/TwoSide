using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnFlower(Vector3 spawnPosition, GameObject flower) // Spawn flower on position
    {
        Instantiate(flower, spawnPosition, Quaternion.identity);
    }
}
