using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private int mouseSensitivity;
    private float xRotation, yRotation;
    private float mouseX, mouseY;
    [SerializeField] private Transform playerCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        mouseX *= Time.deltaTime * mouseSensitivity;
        mouseY *= Time.deltaTime * mouseSensitivity;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 40f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void OnLook(InputValue inputValue)
    {
        mouseX = inputValue.Get<Vector2>().x;
        mouseY = inputValue.Get<Vector2>().y;

    }
}
