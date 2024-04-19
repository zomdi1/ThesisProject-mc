using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_WeaponObject : MonoBehaviour, IInteractable
{
    public F_SO_Weapon WeaponSO;
    public void Interact()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<F_PlayerWeapon>().ChangeWeapon(WeaponSO);
        Destroy(gameObject);
    }

   
}
