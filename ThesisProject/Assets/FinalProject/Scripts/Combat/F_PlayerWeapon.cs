using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_PlayerWeapon : MonoBehaviour
{
    
    private int attackPower;
    public int attackSpeed { get; private set; }
    public Collider Collider { get; private set; }
    public void Start()
    {
        Collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(attackPower,attackSpeed);
        }
    }

    public void ChangeWeapon(F_SO_Weapon WeaponSO)
    {
        GetComponent<MeshFilter>().mesh = WeaponSO.Mesh;
        GetComponent<MeshCollider>().sharedMesh  = WeaponSO.Mesh;
        attackSpeed = WeaponSO.AttackSpeed;
        attackPower = WeaponSO.AttackPower;
    }
}
