using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float time;
    public TextMeshProUGUI winText;
    
    void Update()
    {
        if (!WinTrigger.GetInstance().win)
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
        else
        {
            Win();
        }
    }

    void UpdateTimer(float currentTime)
    {
        float minute = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);
        float hundredth = Mathf.FloorToInt((currentTime  * 100) % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, hundredth);
    }

    void Win()
    {
        winText.text = timerText.text;
        timerText.enabled = false;
        Time.timeScale = 0;
    }
}
