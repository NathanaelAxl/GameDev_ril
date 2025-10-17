using UnityEngine;
using UnityEngine.SceneManagement; // Diperlukan untuk memuat ulang scene

public class GameOverTrigger : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("Seret objek Text atau Panel 'Game Over' yang akan diaktifkan ke sini.")]
    public GameObject gameOverUIObject;

    [Tooltip("Seret tombol 'Retry' ke sini.")]
    public GameObject retryButton;

    [Tooltip("Seret tombol 'Exit' ke sini.")]
    public GameObject exitButton;


    private void Start()
    {
        // Langkah keamanan: Pastikan semua UI Game Over nonaktif saat permainan dimulai.
        if (gameOverUIObject != null) gameOverUIObject.SetActive(false);
        if (retryButton != null) retryButton.SetActive(false);
        if (exitButton != null) exitButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Pertama, kita cek apakah objek yang menyentuh memiliki Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Panggil fungsi untuk memproses Game Over
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        Debug.Log("Game Over! Player menyentuh area berbahaya.");

        // 1. Aktifkan semua UI untuk Game Over
        if (gameOverUIObject != null) gameOverUIObject.SetActive(true);
        if (retryButton != null) retryButton.SetActive(true);
        if (exitButton != null) exitButton.SetActive(true);

        // 2. Hentikan waktu permainan. Ini akan "membekukan" semua fisika dan animasi.
        // --- PERUBAHAN --- Menggunakan nilai yang sangat kecil, bukan nol.
        Time.timeScale = 0.0001f;
    }

    // --- FUNGSI UNTUK TOMBOL ---

    // Fungsi ini akan dipanggil oleh tombol Retry
    public void RetryGame()
    {
        // --- LANGKAH DEBUGGING ---
        // Baris ini akan mencetak pesan ke Console untuk memastikan fungsi ini terpanggil.
        Debug.Log("Tombol Retry DIKLIK dan fungsi RetryGame() BERHASIL dipanggil!");

        // Kembalikan waktu ke normal sebelum memuat ulang scene
        Time.timeScale = 1f;
        
        // Muat ulang scene yang sedang aktif
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi ini akan dipanggil oleh tombol Exit
    public void ExitGame()
    {
        Debug.Log("Tombol Exit ditekan!");
        // Untuk keluar dari aplikasi (hanya berfungsi di build, bukan di Editor)
        // Application.Quit();
    }
}

