using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float time;
    
    void Update()
    {
        if (!WinTrigger.GetInstance().win)
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
        else
        {
            timerText.color = Color.green;
            timerText.fontSize = 60;
        }
    }

    void UpdateTimer(float currentTime)
    {
        float minute = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);
        float hundredth = Mathf.FloorToInt((currentTime  * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, hundredth);
    }
}
