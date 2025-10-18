using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Singleton pattern agar mudah diakses
    public static LevelManager instance;

    [Header("Quest Objects")]
    [Tooltip("Seret objek Portal yang akan diaktifkan ke sini.")]
    public GameObject portalObject;

    // Referensi ke manajer lain untuk memeriksa status quest
    private CoinManager coinManager;
    private KeyManager keyManager;

    private void Awake()
    {
        // Setup Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ambil referensi ke manajer lain secara otomatis
        coinManager = FindObjectOfType<CoinManager>();
        keyManager = FindObjectOfType<KeyManager>();

        // Pastikan portal tidak aktif di awal permainan
        if (portalObject != null)
        {
            portalObject.SetActive(false);
        }
    }

    // Fungsi ini akan dipanggil setiap kali koin atau kunci diambil
    public void CheckWinConditions()
    {
        // Jika salah satu manajer tidak ditemukan, hentikan fungsi untuk menghindari error
        if (coinManager == null || keyManager == null)
        {
            Debug.LogError("CoinManager atau KeyManager tidak ditemukan di scene!");
            return;
        }

        // Cek apakah jumlah koin sudah maksimal DAN kunci sudah diambil
        if (coinManager.GetCurrentCoins() >= coinManager.maxCoins && keyManager.HasKey())
        {
            // Jika semua syarat terpenuhi, aktifkan portal!
            Debug.Log("Semua syarat terpenuhi! Portal diaktifkan.");
            if (portalObject != null)
            {
                portalObject.SetActive(true);
            }
        }
    }
}
