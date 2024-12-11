using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTimer = 15f; // Set the timer duration in seconds
    public Text timerText; // Reference to the UI Text for displaying the timer

    private GameObject pickUpPrompt; // Reference to the existing UI GameObject
    private bool isNearItem = false; // Flag to check if the player is near an item

    void Start()
    {
        Debug.Log("Gamemanager initialized");
        // Find the existing UI element in the scene (ensure it's named correctly)
        pickUpPrompt = GameObject.Find("CallForActionScreen");

        if (pickUpPrompt != null)
            pickUpPrompt.SetActive(false); // Ensure it's hidden initially
        else
            Debug.LogError("PickUpPrompt UI element not found in the scene!");
    }

    void Update()
    {
        // Countdown the game timer
        gameTimer -= Time.deltaTime;
        if (timerText != null)
            timerText.text = "Time Left: " + Mathf.CeilToInt(gameTimer) + "s";

        // Check if the timer has ended
        if (gameTimer <= 0)
        {
            EndGame();
        }

        // Show or hide the pick-up prompt based on proximity to items
        if (pickUpPrompt != null)
        {
            pickUpPrompt.SetActive(isNearItem);
        }
    }

    public void EndGame()
    {
        Debug.Log("Time's up! Switching scenes.");
        // Load the next scene (replace "NextSceneName" with the actual scene name)
        //SceneManager.LoadScene("NextSceneName");
    }

    public void SetNearItem(bool nearItem)
    {
        isNearItem = nearItem;
    }
}
