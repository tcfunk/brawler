using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float gravity = 30f;

    public float maxJumpHeight = 15f;
    private bool isJumping = false;

    private Vector3 movement;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = Vector3.zero;
    }

    private void Update()
    {

        if (controller.isGrounded)
        {
            movement.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            movement.Normalize();
            movement *= movementSpeed;
        }

        // Apply gravity
        movement.y -= gravity * Time.deltaTime;

        // Respond to jump button
        if (!isJumping && controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            //movement.y = maxJumpHeight * gravity;
            movement.y = maxJumpHeight;
            isJumping = true;
        }

        // Remove isJumping flag once we start falling
        if (movement.y < 0) isJumping = false;

        controller.Move(movement * Time.deltaTime);
    }

}
