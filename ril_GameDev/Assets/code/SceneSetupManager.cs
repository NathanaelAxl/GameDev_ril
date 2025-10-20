using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetupManager : MonoBehaviour
{
<<<<<<< HEAD
    // Flag statis agar pesan "Welcome" hanya muncul sekali per sesi permainan
=======
>>>>>>> nima
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
<<<<<<< HEAD
        // --- Bagian 1: Atur Posisi Pemain (Tidak Berubah) ---
=======
>>>>>>> nima
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
        
<<<<<<< HEAD
        // --- Bagian 2: Reset Manajer Lain (Tidak Berubah) ---
        CoinManager.instance?.ResetState();
        KeyManager.instance?.ResetState();
        
        // --- Bagian 3: Tampilkan Pesan Selamat Datang (Baru) ---
=======
        CoinManager.instance?.ResetState();
        KeyManager.instance?.ResetState();
        
>>>>>>> nima
        if (UIMessageManager.instance != null)
        {
            if (scene.name == "map1" && isFirstLoad)
            {
                UIMessageManager.instance.ShowMessage("Welcome to Our game");
<<<<<<< HEAD
                isFirstLoad = false; // Tandai agar tidak muncul lagi saat retry
=======
                isFirstLoad = false;
>>>>>>> nima
            }
            else if (scene.name == "map2")
            {
                UIMessageManager.instance.ShowMessage("Welcome to level 2");
            }
        }
    }
}