using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    public float dayDuration = 0f;
    public float nightDuration = 0f;
    float _timer = 0;
    public bool isNight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }

    void DoNight()
    {
        isNight = true;
    }

    void DoDay()
    {
        isNight = false;
    }
}
