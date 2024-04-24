using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_PlayerQuests : MonoBehaviour
{
    public List<F_Quest> activeQuests;

    public void CheckQuests()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (!activeQuests[i].isActive) break;
            bool allGoalsCompleted = true;
            for(int j = 0; j < activeQuests[i].goals.Count; j++)
            {
                if (!activeQuests[i].goals[j].completed)
                {
                    allGoalsCompleted = false;
                }
            }
            if(allGoalsCompleted)
            {
                activeQuests[i].CompleteQuest();
            }
        }
    }
}
