using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Quest Objects")]
    [Tooltip("Seret objek Portal yang akan diaktifkan ke sini.")]
    public GameObject portalObject;

    private CoinManager coinManager;
    private KeyManager keyManager;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // --- PERBAIKAN ---
        // Menggunakan FindFirstObjectByType yang lebih modern
        coinManager = FindFirstObjectByType<CoinManager>();
        keyManager = FindFirstObjectByType<KeyManager>();

        if (portalObject != null)
        {
            portalObject.SetActive(false);
        }
    }

    public void CheckWinConditions()
    {
        if (coinManager == null || keyManager == null)
        {
            Debug.LogError("CoinManager atau KeyManager tidak ditemukan di scene!");
            return;
        }

        // --- PERBAIKAN ---
        // Menggunakan fungsi publik GetMaxCoins() alih-alih mengakses variabel private
        if (coinManager.GetCurrentCoins() >= coinManager.GetMaxCoins() && keyManager.HasKey())
        {
            Debug.Log("Semua syarat terpenuhi! Portal diaktifkan.");
            if (portalObject != null)
            {
                portalObject.SetActive(true);
            }
        }
    }
}