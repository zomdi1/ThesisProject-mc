using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class F_Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int reward;

    public List<F_Goal> goals;
}
