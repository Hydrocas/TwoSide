using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BugStack
{
    [SerializeField] private BugData bugData;
    [SerializeField] private int givenNumber;

    public BugStack(BugData bugData, int givenNumber = 1)
    {
        this.bugData = bugData;
        this.givenNumber = givenNumber;
    }
}
