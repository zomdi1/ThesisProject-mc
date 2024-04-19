using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_weapon", menuName = "Weapon")] //creates a new file from this script
public class F_SO_Weapon : ScriptableObject
{
    public string Name;
    public Mesh Mesh;
    public int AttackSpeed;
    public int AttackPower;
}
