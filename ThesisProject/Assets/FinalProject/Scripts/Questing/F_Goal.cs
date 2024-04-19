using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class F_Goal
{
    public GoalType goalType;
    public string objectiveName;
    public bool completed;
    public int currentAmount;
    public int requiredAmount;
    public void Init()
    {
        if (goalType == GoalType.Interact)
        {
            F_EventController.Instance.OnQuestItemInterraction += ObjectInteracted;
        }
    }


    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        completed = true;
        GameObject.FindWithTag("Player").GetComponent<F_PlayerQuests>().CheckQuests();
        Debug.Log("Goal completed");
    }

    void ObjectInteracted(string objectName)
    {
        if (objectName == objectiveName)
        {
            currentAmount++;
            Evaluate();
        }
    }


}
public enum GoalType
{
    Interact,
    Kill
}