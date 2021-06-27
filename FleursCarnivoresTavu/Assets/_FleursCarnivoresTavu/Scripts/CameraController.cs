using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 _cameraDayPosition;
    Vector3 _cameraNightPosition;
    float timer;
    bool _flipped = false;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraDayPosition = transform.position;
        _cameraNightPosition = new Vector3 (transform.position.x, -transform.position.y, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Flip Camera at fixed interval
        if(timer > 5f)
        {
            FlipCamera();
            timer = 0f;
        }
        //Debug.Log(timer);
    }

    void FlipCamera()
    {
        //Debug.Log(_flipped);
        if (_flipped)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = _cameraDayPosition;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position = _cameraNightPosition;
        }

        _flipped = !_flipped;
    }
}
