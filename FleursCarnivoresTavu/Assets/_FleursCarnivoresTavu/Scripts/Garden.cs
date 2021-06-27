using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Garden : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateGarden(float direction, float rotationSpeed)
    {
        transform.DORotate(new Vector3(0, 0, 180 * direction), rotationSpeed, RotateMode.FastBeyond360);
    }
}
