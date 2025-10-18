using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float timeRemaining = 90; // Waktu awal dalam detik
    private bool timerIsRunning = true;

    // --- TAMBAHAN ---
    // Variabel untuk menampung referensi ke script GameOverTrigger
    [Header("Game Over Logic")]
    [Tooltip("Seret objek yang memiliki script GameOverTrigger ke sini.")]
    public GameOverTrigger gameOverTrigger;

    void Update()
    {
        // Hanya jalankan timer jika timerIsRunning adalah true
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

                // --- TAMBAHAN ---
                // Panggil fungsi TriggerGameOver() dari script lain
                // Cek dulu untuk memastikan referensinya tidak kosong
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

        // Menghitung menit dan detik
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Memformat string menjadi "00:00"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

