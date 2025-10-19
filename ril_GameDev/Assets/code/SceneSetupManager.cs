using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetupManager : MonoBehaviour
{
    private void OnEnable()
    {
        // Berlangganan event sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Berhenti berlangganan event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Fungsi ini akan berjalan secara otomatis setiap kali scene dimuat
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("SceneSetupManager: Scene '" + scene.name + "' dimuat. Memulai setup...");

        // --- Bagian 1: Atur Posisi Pemain ---
        GameObject player = GameObject.FindWithTag("Player");
        GameObject startPoint = GameObject.FindWithTag("StartPoint"); // Kita akan buat Tag ini

        if (player != null && startPoint != null)
        {
            // Pindahkan pemain ke posisi start point
            player.transform.position = startPoint.transform.position;
            
            // Reset fisika pemain (penting agar tidak meluncur saat spawn)
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            Debug.Log("Pemain berhasil dipindahkan ke StartPoint.");
        }
        else
        {
            if (player == null) Debug.LogWarning("Objek dengan Tag 'Player' tidak ditemukan.");
            if (startPoint == null) Debug.LogWarning("Objek dengan Tag 'StartPoint' tidak ditemukan di scene ini.");
        }

        // --- Bagian 2: Reset Manajer Lain ---
        if (CoinManager.instance != null)
        {
            CoinManager.instance.ResetState();
        }
        
        if (KeyManager.instance != null)
        {
            KeyManager.instance.ResetState();
        }
        
        // Anda bisa menambahkan reset manajer lain di sini jika ada
    }
}
