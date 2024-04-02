using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    float timeLeft;
    private int currentMinutes;
    private int currentSeconds;
    private bool isTimerRunning = false;


    Text mText;
    void Start()
    {
        isTimerRunning = true;
        currentMinutes = minutes;
        currentSeconds = seconds;
        timeLeft = minutes * 60 + seconds;
        mText = this.gameObject.GetComponent<Text>();
        Assert.IsNotNull(mText);
    }

    private void Update()
    {
        // Check if the timer is running
        if (isTimerRunning && mText !=null)
        {
            mText.text = string.Format("{0:00}:{1:00}",GetCurrentMinutes(), GetCurrentSeconds());

            // Reduce time left
            timeLeft -= Time.deltaTime;

            // Check if time is up
            if (timeLeft <= 0)
            {
                // Timer has reached the end
                StopTimer();
                Debug.Log("Time's up!");
                OnTimerOver();
            }
        }

       
    }

    public int GetCurrentMinutes()
    {
        return Mathf.FloorToInt(timeLeft / 60);
    }

    // Get the current time in seconds
    public int GetCurrentSeconds()
    {
        return Mathf.FloorToInt(timeLeft % 60);
    }

    // Stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void OnTimerOver()
    {
        //TODO
        gM.FinDePartida();
    }
}
