using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_InteractGoal : F_Goal
{
    string interactableObjectName;
    public override void Init()
    {
        base.Init();
        F_EventController.Instance.OnQuestItemInterraction += ObjectInteracted;
    }
    void ObjectInteracted(string objectName) 
    {
        if(objectName == interactableObjectName)
        {
            currentAmount++;
            Evaluate();
        }
    }
}
