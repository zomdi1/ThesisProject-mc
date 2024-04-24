using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class F_Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int reward;

    public List<F_Goal> goals;
    public void CompleteQuest()
    {
        isActive = false;
        Debug.Log(title + " was completed");
    }
}
