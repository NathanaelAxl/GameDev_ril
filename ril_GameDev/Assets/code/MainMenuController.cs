// --- TAMBAHAN BARU: Diperlukan untuk mengontrol Editor ---
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
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
        // Ganti "map1" dengan nama scene level pertama Anda
        SceneManager.LoadScene("map1"); 
    }

    // --- FUNGSI YANG DIPERBARUI ---
    // Fungsi ini sekarang memiliki dua perilaku berbeda
    public void QuitGame()
    {
        Debug.Log("Tombol Quit ditekan!");

        // Perintah ini hanya akan dijalankan JIKA Anda berada di dalam Unity Editor
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        
        // Perintah ini hanya akan dijalankan JIKA Anda berada di dalam game yang sudah di-build
        #else
        Application.Quit();
        #endif
    }
}

