using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Enum untuk memilih jenis perilaku portal
    public enum PortalType { GoToNextLevel, ReturnToMainMenu }

    [Header("Portal Settings")]
    [Tooltip("Pilih perilaku yang akan dilakukan oleh portal ini.")]
    public PortalType portalBehavior;

    [Tooltip("Masukkan nama scene tujuan.")]
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Cek jika yang menyentuh adalah Player
        if (other.CompareTag("Player"))
        {
            switch (portalBehavior)
            {
                case PortalType.GoToNextLevel:
                    // Perilaku lama: Langsung pindah ke scene selanjutnya
                    Debug.Log("Pindah ke level selanjutnya: " + nextSceneName);
                    SceneManager.LoadScene(nextSceneName);
                    break;

                case PortalType.ReturnToMainMenu:
                    // Perilaku baru (sama seperti tombol Exit): Hancurkan objek lalu pindah scene
                    Debug.Log("Kembali ke Main Menu... Menghancurkan objek persisten.");

                    // 1. Kembalikan waktu ke normal
                    Time.timeScale = 1f;

                    // 2. Cari dan hancurkan objek Player
                    GameObject playerObject = GameObject.FindWithTag("Player");
                    if (playerObject != null)
                    {
                        Destroy(playerObject);
                    }

                    // --- PERBAIKAN ---
                    // Menggunakan GameOverTrigger.instance yang benar, bukan GameManager
                    if (GameOverTrigger.instance != null)
                    {
                        Destroy(GameOverTrigger.instance.gameObject);
                    }
                    
                    // 4. Setelah semua dihancurkan, baru muat scene Main Menu
                    SceneManager.LoadScene(nextSceneName);
                    break;
            }
        }
    }
}