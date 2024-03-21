using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class F_PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB; // Reference to the Rigidbody component of the character

    private Vector3 movementInput; // Stores movement input received from the player
    private Vector3 movementVector; // Stores the resulting movement vector
    [SerializeField] private float movementSpeed; // Movement speed of the character

    void Start()
    {
        characterRB = GetComponent<Rigidbody>(); // Getting the Rigidbody component attached to the character
    }

    void FixedUpdate()
    {
       
        if (movementInput != Vector3.zero)
        {
            // Calculate movement vector based on input and current orientation of the character
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
        }

        // Set the velocity of the character's Rigidbody to move it
        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);

    }

    // This method is invoked when there is movement input
    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
        // Playing step sound when movement input is registered
        F_SoundManager.instance.PlayAudioClipOnLoop(GetComponent<AudioSource>(), F_SoundManager.instance.stepAudio);
    }
    private void OnMovementStop(InputValue input)
    {
        F_SoundManager.instance.StopPlayingFromSource(GetComponent<AudioSource>());
        movementVector = Vector3.zero;
    }
}
