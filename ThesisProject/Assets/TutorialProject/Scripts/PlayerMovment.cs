using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovment : MonoBehaviour
{
    //[SerializeField]

    private Rigidbody characterRB;
    private Vector3 movmentInput;
    public Vector3 movmentVector;
    private float startingSpeed;
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float runMultiplier;
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();

       startingSpeed = movmentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (movmentInput != Vector3.zero) 
        {
            movmentVector = movmentInput.x * transform.right + movmentInput.z * transform.forward;
            movmentVector.y = 0;
        }

        characterRB.velocity = movmentVector * Time.fixedDeltaTime * movmentSpeed;
    }

    private void OnMovement(InputValue input)
    {
        movmentInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    private void OnMovementStop(InputValue input)
    {
        
        movmentInput = Vector3.zero;
        movmentVector = Vector3.zero;
    }

    private void OnRun()
    {
        movmentSpeed *= runMultiplier;
    }

    private void OnRunStop()
    {
        movmentSpeed = startingSpeed;
    }
}
