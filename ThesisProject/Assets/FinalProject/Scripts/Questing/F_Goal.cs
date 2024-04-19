using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Goal
{
    public string description;
    public bool completed;
    public int currentAmount;
    public int requiredAmount;

    public virtual void Init()
    {
        // init stuff
    }

    public void Evaluate()
    {
        if(currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        completed = true;
    }
}
