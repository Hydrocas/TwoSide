using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayCycleManager : MonoBehaviour
{
    [SerializeField] private float dayDuration = 10f;
    [SerializeField] private float nightDuration = 5f;
    [SerializeField] private float gardenRotationSpeed;
    [SerializeField] private Garden garden;

    [HideInInspector]
    public bool isNight = false;

    private float _timer = 0f;




    // Start is called before the first frame update
    void Awake()
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
        garden.RotateGarden(-1, 2f);
    }

    void DoDay()
    {
        isNight = false;
        //Debug.Log(isNight);
        garden.RotateGarden(0, 2f);
    }
}
