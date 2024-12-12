using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;         // The player transform
    public Vector3 offset;           // The camera's offset from the player
    public float smoothSpeed = 0.125f; // Smooth transition speed
    public float minDistance = 2f;   // Minimum distance from player
    public float maxDistance = 5f;   // Maximum distance from player

    private Vector3 currentPosition;
    private Vector3 desiredPosition;

    void Update()
    {
        // Calculate the desired position
        desiredPosition = player.position + offset;

        // Check if there is an obstacle between the camera and the player
        RaycastHit hit;
        if (Physics.Linecast(player.position, desiredPosition, out hit))
        {
            // If there's an obstacle, adjust the camera position
            currentPosition = hit.point;
        }
        else
        {
            // If there's no obstacle, move the camera to the desired position
            currentPosition = desiredPosition;
        }

        // Smoothly interpolate between the current and desired positions
        transform.position = Vector3.Lerp(transform.position, currentPosition, smoothSpeed);
        
        // Optionally, look at the player
        transform.LookAt(player);
    }
}

