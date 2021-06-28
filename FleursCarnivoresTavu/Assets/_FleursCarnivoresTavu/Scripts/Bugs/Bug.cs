using System;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private BugData bugData;
    public event Action<Bug> OnCollected;

    public void Init(BugData bugData)
    {
        this.bugData = bugData;
        GetComponent<Animator>().runtimeAnimatorController = bugData.AnimatorController;
    }

    public BugData Collect()
    {
        OnCollected?.Invoke(this);
        Disapear();
        return bugData;
    }

    public void Disapear()
    {
        Destroy(gameObject);
    }
}
