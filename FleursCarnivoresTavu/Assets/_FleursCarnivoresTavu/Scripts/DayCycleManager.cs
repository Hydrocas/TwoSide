using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    public float dayDuration = 10f;
    public float nightDuration = 5f;
    float _timer = 0f;
    [HideInInspector]
    public bool isNight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>= dayDuration && !isNight)
        {
            DoNight();
        }
        if(_timer>= dayDuration + nightDuration && isNight)
        {
            DoDay();
            _timer = 0f;
        }
    }

    void DoNight()
    {
        isNight = true;
        //Debug.Log(isNight);
    }

    void DoDay()
    {
        isNight = false;
        //Debug.Log(isNight);
    }
}
