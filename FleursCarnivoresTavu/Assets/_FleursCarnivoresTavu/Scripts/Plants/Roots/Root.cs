using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Root : Plant
{
    [SerializeField] private float[] scaleGrowthLevel;
    [SerializeField] private BugStack[] askedBugs1 = null;
    [SerializeField] private BugStack[] askedBugs2 = null;

    [SerializeField] private Image[] bugsImg;
    [SerializeField] private Text[] bugsTxt;
    [SerializeField] private CanvasGroup[] canvasGroup;

    private Flower linkedFlower;
    private Animator animator;

    private BugStack[] CurrentAskedBug
    {
        get
        {
            if(growthLevel == 0)
            {
                return askedBugs1;
            }

            if (growthLevel == 1)
            {
                return askedBugs2;
            }

            return null;
        }
    }

    public void Init(Flower linkedFlower)
    {
        animator = GetComponent<Animator>();
        this.linkedFlower = linkedFlower;
        Grow();
        RemoveUI();
    }

    public override bool Grow()
    {
        if(!base.Grow()) return false;

        transform.localScale = Vector3.one * scaleGrowthLevel[growthLevel];
        linkedFlower.Grow();
        UpdateAskedBugsUI();

        return true;
    }

    public void Feed()
    {
        animator.SetTrigger("eat");
    }

    public void SetDayMode()
    {
        RemoveUI();
    }

    public void SetNightMode()
    {
        UpdateAskedBugsUI();
    }

    private void UpdateAskedBugsUI()
    {
        BugStack[] currentAskedBug = CurrentAskedBug;

        for (int i = 0; i < currentAskedBug.Length; i++)
        {
            canvasGroup[i].alpha = 1;
            bugsTxt[i].text = currentAskedBug[i].GivenNumber.ToString();
            bugsImg[i].sprite = currentAskedBug[i].BugData.Sprite;
        }
    }

    private void RemoveUI()
    {
        for (int i = 0; i < canvasGroup.Length; i++)
        {
            canvasGroup[i].alpha = 0;
        }
    }
}
