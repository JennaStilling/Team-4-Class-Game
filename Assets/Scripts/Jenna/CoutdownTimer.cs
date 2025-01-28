using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float startTime;

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = startTime; 
        isRunning = true; 
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
            currentTime -= Time.deltaTime;
            
            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false; 
            }
            
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = currentTime.ToString("F1");
    }
}