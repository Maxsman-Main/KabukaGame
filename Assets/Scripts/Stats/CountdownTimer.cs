using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float duration = 60.0f;
    public Action onTimerExpired;

    private Text timerText;

    private float currentTime;

    private void Start()
    {
        StartTimer();
        timerText = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                onTimerExpired?.Invoke();
            }
        }
        UpdateTimerText();
    }

    public void StartTimer()
    {
        currentTime = duration;
    }
    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
    }
}