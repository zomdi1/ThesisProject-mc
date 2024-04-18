using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Weapon : MonoBehaviour
{
    [SerializeField] private int attackPower;
    [field: SerializeField] public int attackSpeed { get; private set; }
    public void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Weapon collided");
        if (other.GetComponent<IDamageable>() != null)
        {
            Debug.Log("Weapon collided with a damageable");
            other.GetComponent<IDamageable>().TakeDamage(attackPower);
        }
    }
}
