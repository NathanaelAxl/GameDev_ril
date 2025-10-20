<<<<<<< HEAD
// --- TAMBAHAN BARU: Diperlukan untuk mengontrol Editor ---
=======
>>>>>>> nima
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
<<<<<<< HEAD
    // Start() akan berjalan secara otomatis setiap kali scene ini dimuat
    private void Start()
    {
        // Pastikan waktu permainan kembali normal, sebagai langkah pengamanan
        Time.timeScale = 1f;

        // Paksa kursor untuk selalu tidak terkunci dan terlihat di Main Menu
=======
    private void Start()
    {
        Time.timeScale = 1f;

>>>>>>> nima
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

<<<<<<< HEAD
    // Fungsi ini akan dipanggil oleh tombol Play
    public void PlayGame()
    {
        // Ganti "map1" dengan nama scene level pertama Anda
        SceneManager.LoadScene("map1"); 
    }

    // --- FUNGSI YANG DIPERBARUI ---
    // Fungsi ini sekarang memiliki dua perilaku berbeda
=======
    public void PlayGame()
    {
        SceneManager.LoadScene("map1"); 
    }

>>>>>>> nima
    public void QuitGame()
    {
        Debug.Log("Tombol Quit ditekan!");

<<<<<<< HEAD
        // Perintah ini hanya akan dijalankan JIKA Anda berada di dalam Unity Editor
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        
        // Perintah ini hanya akan dijalankan JIKA Anda berada di dalam game yang sudah di-build
=======
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        
>>>>>>> nima
        #else
        Application.Quit();
        #endif
    }
}

