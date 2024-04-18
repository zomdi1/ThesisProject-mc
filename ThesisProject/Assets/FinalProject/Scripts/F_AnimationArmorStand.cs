using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public interface IDamageable
{
    public int Health { get;  set; }
    public Slider healthBar { get; set; }
    public bool canTakeDamage { get; set; }
    public IEnumerator DamageCoolDown(int damageDelay);
    public void TakeDamage(int damageAmount);
}
public class F_AnimationArmorStand : MonoBehaviour,IInteractable, IDamageable
{
    [field:SerializeField] public int Health { get; set; }
    [field: SerializeField] public Slider healthBar { get ; set ; }
    public bool canTakeDamage { get; set; } = true;

    public IEnumerator DamageCoolDown(int damageDelay)
    {
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }

    public void Interact()
    {
        if (GetComponent<Animation>().isPlaying)
        {
            return;
        }
        GetComponent<Animation>().Play();
    }

    public void TakeDamage(int damageAmount)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            Health -= damageAmount;
            Debug.Log(Health.ToString());
            //healthBar.value = Health;
            StartCoroutine(DamageCoolDown(2));
        }
    }
}
