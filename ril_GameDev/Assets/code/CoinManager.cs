using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Diperlukan untuk mereset saat scene dimuat

public class CoinManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI coinText;

    // maxCoins sekarang akan dihitung secara otomatis
    private int maxCoins;
    private int currentCoins = 0;
    
    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    // Berlangganan event saat script aktif
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Berhenti berlangganan saat script nonaktif
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    // Fungsi ini akan berjalan setiap kali scene dimuat (termasuk setelah retry)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ganti "map1" dengan nama scene permainan Anda jika berbeda
        if (scene.name == "map1") 
        {
            ResetState();
        }
    }
    
    // Fungsi untuk setup awal dan reset
    public void ResetState()
    {
        // Hitung semua objek dengan Tag "Coin" di scene untuk menentukan jumlah maksimal
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Reset jumlah koin yang dikumpulkan
        currentCoins = 0;
        
        // Perbarui teks UI ke nilai awal
        UpdateCoinText();
        Debug.Log("CoinManager di-reset. Ditemukan " + maxCoins + " koin di level ini.");
    }

    public void CollectCoin()
    {
        currentCoins++;
        UpdateCoinText();

        // Beri tahu LevelManager untuk memeriksa kondisi menang
        LevelManager.instance?.CheckWinConditions();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"Kumpulkan: {currentCoins}/{maxCoins} Coins";
        }
    }
    
    // Fungsi ini dibutuhkan oleh LevelManager
    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    // Fungsi ini juga dibutuhkan oleh LevelManager
    public int GetMaxCoins()
    {
        return maxCoins;
    }
}