using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Garden : MonoBehaviour
{

    [SerializeField] private GameObject gardenGround;
    [SerializeField] private GameObject background;
    private Vector3 bgDayPos;
    private Vector3 bgNightPos;
    // Start is called before the first frame update
    public void Init()
    {
        bgDayPos = background.transform.position;

        bgNightPos = new Vector3(background.transform.position.x * -1f, background.transform.position.y + 0.55f, background.transform.position.z);

    }

    public void RotateGarden(float direction, float rotationSpeed, bool isNight)
    {
        gardenGround.transform.DORotate(new Vector3(0, 0, 180 * direction), rotationSpeed, RotateMode.FastBeyond360);
        background.transform.DORotate(new Vector3(background.transform.rotation.eulerAngles.x, background.transform.rotation.eulerAngles.y, 180 * direction), rotationSpeed, RotateMode.FastBeyond360);
        if (isNight)
        {
            background.transform.DOMove(bgNightPos, rotationSpeed, false);
        }
        if (!isNight)
        {
            background.transform.DOMove(bgDayPos, rotationSpeed, false);
        }
    }
}
