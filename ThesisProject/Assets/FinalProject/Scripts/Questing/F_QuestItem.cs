using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_QuestItem : MonoBehaviour, IInteractable
{
    public string questItemName;
    public void Interact()
    {
        F_EventController.Instance.TriggerOnQuestItemInterraction(questItemName);
    }
}
