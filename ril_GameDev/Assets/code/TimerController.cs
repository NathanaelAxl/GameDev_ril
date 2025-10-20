using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float timeRemaining = 90;
    private bool timerIsRunning = true;

    [Header("Game Over Logic")]
    [Tooltip("Seret objek yang memiliki script GameOverTrigger ke sini.")]
    public GameOverTrigger gameOverTrigger;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Waktu telah habis!");
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);

                if (gameOverTrigger != null)
                {
                    gameOverTrigger.TriggerGameOver();
                }
                else
                {
                    Debug.LogError("Referensi GameOverTrigger belum diatur di Inspector!");
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

