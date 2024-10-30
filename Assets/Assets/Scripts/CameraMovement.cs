using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform player;           // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothing factor for the camera movement

    void LateUpdate()
    {
        // Desired position is the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;
        
        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Update the camera's position
        transform.position = smoothedPosition;

        // Optionally, make the camera look at the player
        transform.LookAt(player);
    }
}

