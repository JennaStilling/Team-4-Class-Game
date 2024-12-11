using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign your TextMeshProUGUI in the Inspector
    public float startTime; // Set the starting time in seconds

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = startTime; // Initialize the current time
        isRunning = true; // Start the timer
    }

    public void StartTimer(float time)
    {
        currentTime = time;
        isRunning = true;
    }
    
    void Update()
    {
        if (isRunning)
        {
            // Decrease time
            currentTime -= Time.deltaTime;

            // Clamp time to not go below 0
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false; // Stop the timer
            }

            // Update the displayed time
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        // Format time to one decimal place
        timerText.text = currentTime.ToString("F1");
    }
}