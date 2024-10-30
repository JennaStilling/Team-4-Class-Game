using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Speed of the player
    public float rotationSpeed = 720f;  // Speed of rotation

    private Vector3 moveDirection;

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");  // Left and right
        float verticalInput = Input.GetAxis("Vertical");  // Forward and backward

        // Calculate movement direction
        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the player
        if (moveDirection.magnitude >= 0.1f)
        {
            // Calculate the target angle
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Move in the direction we are facing
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
}

