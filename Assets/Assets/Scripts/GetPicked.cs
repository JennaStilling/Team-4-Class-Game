using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class GetPicked : MonoBehaviour
{
    
    public KeyCode collectKey = KeyCode.E; // Set the collect key to "E"
    public float collectRange = 2f; // Set the range within which the player can collect the object
    

    private bool collected = false;
    private static List<GameObject> collectedItems = new List<GameObject>(); // List to hold collected items

    private void Update()
    {
        if (Input.GetKeyDown(collectKey) && collected)
        {
            Debug.Log("Collectible collected!"); // Display message in the console
            AddToCollectedItems(gameObject); // Add the collected item to the list
            Destroy(gameObject); // Destroy the collectible object
            DisplayCollectedCount(); // Display the amount of collected items
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collected = true;
            Debug.Log("Player touched the collectible!"); // Display message in the console
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collected = false;
            Debug.Log("Player is no longer touching the collectible."); // Display message in the console
        }
    }

    private void AddToCollectedItems(GameObject item)
    {
        collectedItems.Add(item);
        
    }

    private void DisplayCollectedCount()
    {
        int count = collectedItems.Count;
        Debug.Log("Total collected items: " + count);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectRange);
    }
}