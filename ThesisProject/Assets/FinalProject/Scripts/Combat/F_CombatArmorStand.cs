using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IDamageable
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public F_HealthBar HealthBar { get; set; }
    public bool canTakeDamage { get; set; }
    public IEnumerator DamageCoolDown(int damageDelay);
    public void TakeDamage(int damageAmount,int damageDelay);
    public void Death();
}
public class F_CombatArmorStand : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    
    public bool canTakeDamage { get; set; } = true;
    public F_HealthBar HealthBar { get ; set ; }
    public int MaxHealth { get; set ; }

    private void Start()
    {
        HealthBar = GetComponentInChildren<F_HealthBar>();
        MaxHealth = Health;
        Debug.Log(MaxHealth);
    }

    public IEnumerator DamageCoolDown(int damageDelay)
    {
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
    public void TakeDamage(int damageAmount, int damageDelay)
    {
        if (canTakeDamage && Health>0)
        {
            canTakeDamage = false;
            Health -= damageAmount;
            HealthBar.UpdateHealthBar((float)Health/MaxHealth);
            StartCoroutine(DamageCoolDown(damageDelay));
        }
        if (Health <= 0)
        { Death();}
    }

    public void Death()
    {
       Destroy(gameObject);
    }
}
