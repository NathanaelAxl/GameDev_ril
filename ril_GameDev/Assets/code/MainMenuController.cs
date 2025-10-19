using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // --- TAMBAHAN BARU ---
    // Start() akan berjalan secara otomatis setiap kali scene ini dimuat
    private void Start()
    {
        // Pastikan waktu permainan kembali normal, sebagai langkah pengamanan
        Time.timeScale = 1f;

        // Paksa kursor untuk selalu tidak terkunci dan terlihat di Main Menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Fungsi ini akan dipanggil oleh tombol Play
    public void PlayGame()
    {
        // Ganti "Map1" dengan nama scene level pertama Anda
        SceneManager.LoadScene("map1"); 
    }

    // Fungsi ini akan dipanggil oleh tombol Quit
    public void QuitGame()
    {
        // Perintah ini hanya berfungsi saat game sudah di-build (bukan di Editor)
        Debug.Log("Keluar dari game!"); // Pesan ini akan muncul di Console Editor
        Application.Quit();
    }
}

