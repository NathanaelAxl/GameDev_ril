using UnityEngine;
using TMPro;
<<<<<<< HEAD
using UnityEngine.SceneManagement; // Diperlukan untuk mereset saat scene dimuat
=======
using UnityEngine.SceneManagement;
>>>>>>> nima

public class CoinManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI coinText;

<<<<<<< HEAD
    // maxCoins sekarang akan dihitung secara otomatis
=======
>>>>>>> nima
    private int maxCoins;
    private int currentCoins = 0;
    
    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
<<<<<<< HEAD
    
    // Berlangganan event saat script aktif
=======

>>>>>>> nima
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

<<<<<<< HEAD
    // Berhenti berlangganan saat script nonaktif
=======
>>>>>>> nima
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
<<<<<<< HEAD
    
    // Fungsi ini akan berjalan setiap kali scene dimuat (termasuk setelah retry)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ganti "map1" dengan nama scene permainan Anda jika berbeda
=======

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
>>>>>>> nima
        if (scene.name == "map1") 
        {
            ResetState();
        }
    }
    
<<<<<<< HEAD
    // Fungsi untuk setup awal dan reset
    public void ResetState()
    {
        // Hitung semua objek dengan Tag "Coin" di scene untuk menentukan jumlah maksimal
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Reset jumlah koin yang dikumpulkan
        currentCoins = 0;
        
        // Perbarui teks UI ke nilai awal
=======
    public void ResetState()
    {
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        currentCoins = 0;
        
>>>>>>> nima
        UpdateCoinText();
        Debug.Log("CoinManager di-reset. Ditemukan " + maxCoins + " koin di level ini.");
    }

    public void CollectCoin()
    {
        currentCoins++;
        UpdateCoinText();

<<<<<<< HEAD
        // Beri tahu LevelManager untuk memeriksa kondisi menang
=======
>>>>>>> nima
        LevelManager.instance?.CheckWinConditions();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"Kumpulkan: {currentCoins}/{maxCoins} Coins";
        }
    }
    
<<<<<<< HEAD
    // Fungsi ini dibutuhkan oleh LevelManager
=======
>>>>>>> nima
    public int GetCurrentCoins()
    {
        return currentCoins;
    }

<<<<<<< HEAD
    // Fungsi ini juga dibutuhkan oleh LevelManager
=======
>>>>>>> nima
    public int GetMaxCoins()
    {
        return maxCoins;
    }
}