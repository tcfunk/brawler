using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float gravity = 10f;

    private Vector3 movement;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = Vector3.zero;
    }

    private void Update()
    {
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized * movementSpeed;
        //transform.position = Vector3.Lerp(transform.position, transform.position + movement, Time.deltaTime);
        //Vector3.MoveTowards(transform.position, transform.position + movement, movementSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            movement.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            movement.Normalize();
            movement *= movementSpeed;
        }

        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
    }

}
