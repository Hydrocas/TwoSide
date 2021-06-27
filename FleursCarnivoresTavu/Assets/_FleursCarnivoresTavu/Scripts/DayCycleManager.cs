using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayCycleManager : MonoBehaviour
{
    [SerializeField] private float dayDuration = 10f;
    [SerializeField] private float nightDuration = 5f;
    [SerializeField] private float gardenRotationSpeed = 2f;
    [SerializeField] private Garden garden;

    [HideInInspector]
    public bool isNight = false;

    private float _timer = 0f;

    public event Action OnDay;
    public event Action OnNight;

    public float DayProgress => isNight ? -1 : Mathf.InverseLerp(0, dayDuration, _timer);

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>= dayDuration && !isNight)
        {
            _timer = 0f;
            DoNight();
        }
        if(_timer>= nightDuration && isNight)
        {
            _timer = 0f;
            DoDay();
        }
    }

    void DoNight()
    {

        isNight = true;
        garden.RotateGarden(-1, gardenRotationSpeed, isNight);
        OnNight?.Invoke();
        //Debug.Log(isNight);

    }

    void DoDay()
    {

        isNight = false;
        garden.RotateGarden(0, gardenRotationSpeed, isNight);
        OnDay?.Invoke();
        //Debug.Log(isNight);

    }
}
