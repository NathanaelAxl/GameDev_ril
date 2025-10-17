using UnityEngine;
using TMPro; // Gunakan ini jika Anda memakai TextMeshPro
// using UnityEngine.UI; // Hapus komentar ini jika Anda memakai Text biasa

public class TimerController : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText; // Ganti menjadi public Text timerText; jika memakai Text biasa

    [Header("Timer Settings")]
    public float timeRemaining = 60; // Waktu awal dalam detik
    private bool timerIsRunning = false;

    void Start()
    {
        // Secara otomatis memulai timer saat game berjalan
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Kurangi waktu setiap frame
                timeRemaining -= Time.deltaTime;
                // Panggil fungsi untuk menampilkan waktu
                DisplayTime(timeRemaining);
            }
            else
            {
                // Apa yang terjadi ketika waktu habis
                Debug.Log("Waktu telah habis!");
                timeRemaining = 0;
                timerIsRunning = false;
                // Di sini Anda bisa menambahkan logika game over, misalnya:
                // GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Menambahkan 1 detik agar tidak langsung menampilkan angka di bawahnya (misal: 59, bukan 60)
        timeToDisplay += 1;

        // Menghitung menit dan detik
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Memformat string menjadi "00:00"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
