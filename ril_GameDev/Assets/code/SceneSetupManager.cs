using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetupManager : MonoBehaviour
{
    // Flag statis agar pesan "Welcome" hanya muncul sekali per sesi permainan
    private static bool isFirstLoad = true;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // --- Bagian 1: Atur Posisi Pemain (Tidak Berubah) ---
        GameObject player = GameObject.FindWithTag("Player");
        GameObject startPoint = GameObject.FindWithTag("StartPoint");
        if (player != null && startPoint != null)
        {
            player.transform.position = startPoint.transform.position;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        // --- Bagian 2: Reset Manajer Lain (Tidak Berubah) ---
        CoinManager.instance?.ResetState();
        KeyManager.instance?.ResetState();
        
        // --- Bagian 3: Tampilkan Pesan Selamat Datang (Baru) ---
        if (UIMessageManager.instance != null)
        {
            if (scene.name == "map1" && isFirstLoad)
            {
                UIMessageManager.instance.ShowMessage("Welcome to Our game");
                isFirstLoad = false; // Tandai agar tidak muncul lagi saat retry
            }
            else if (scene.name == "map2")
            {
                UIMessageManager.instance.ShowMessage("Welcome to level 2");
            }
        }
    }
}