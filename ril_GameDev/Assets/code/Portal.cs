using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Masukkan nama scene selanjutnya yang akan dimuat.")]
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Cek jika yang menyentuh adalah Player
        if (other.CompareTag("Player"))
        {
            // Pastikan nama scene tidak kosong untuk menghindari error
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log("Pindah ke scene: " + nextSceneName);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Nama scene selanjutnya belum diatur di Inspector Portal!");
            }
        }
    }
}
