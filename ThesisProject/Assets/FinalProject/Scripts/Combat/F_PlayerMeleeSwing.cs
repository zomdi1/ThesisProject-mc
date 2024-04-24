using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class F_PlayerMeleeSwing : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    private F_PlayerMovement playerMovement;
    public  F_PlayerWeapon currentWeapon;
    private bool canAttack = true;
    void Start()
    {
        playerMovement = GetComponent<F_PlayerMovement>(); // Getting the Rigidbody component attached to the character
        animator = GetComponent<Animator>(); // Getting the Animator component attached to the character
        currentWeapon = GetComponentInChildren<F_PlayerWeapon>();
        currentWeapon.Collider.enabled = false;
    }
    private void OnAttack(InputValue input)
    {
        if (animator != null && playerMovement.movementVector == Vector3.zero && canAttack)
        {
           
            animator.SetTrigger("IsSwinging");
            StartCoroutine(DelayColliderActivation()); // We do this step to ensure that the target doesnt take damage if the sword is already colliding when swings is activated.
            canAttack = false;
            StartCoroutine(AttackCooldown());

        }
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(currentWeapon.attackSpeed);
        currentWeapon.Collider.enabled = false;
        canAttack = true;
    }
    private IEnumerator DelayColliderActivation()
    {
        yield return new WaitForSeconds(0.5f);
        currentWeapon.Collider.enabled = true;
    }
}
