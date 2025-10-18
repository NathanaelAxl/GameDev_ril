using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq; // Dibutuhkan untuk menggunakan fungsi .Where() dan .ToList()

public class CoinManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI coinText;

    [Header("Coin Settings")]
    public int maxCoins = 10;
    private int currentCoins = 0;

    [Header("Object Pool")]
    [Tooltip("Seret semua objek koin yang akan digunakan dari Hierarchy ke sini.")]
    public List<GameObject> coinPool; 

    [Header("Spawn Settings")]
    [Tooltip("Seret semua objek kosong yang menjadi titik spawn ke sini.")]
    public List<Transform> spawnPoints; 
    
    public static CoinManager instance;

    private void Awake()
    {
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
        // Di awal permainan, pastikan semua koin tidak aktif
        foreach (var coin in coinPool)
        {
            coin.SetActive(false);
        }

        // Panggil fungsi untuk memunculkan batch koin pertama
        SpawnCoinBatch();
        UpdateCoinText();
    }

    public void CollectCoin()
    {
        currentCoins++;
        if (currentCoins > maxCoins)
        {
            currentCoins = maxCoins;
        }
        UpdateCoinText();

        // Beri tahu LevelManager untuk memeriksa kondisi menang
        LevelManager.instance?.CheckWinConditions();

        if (currentCoins >= maxCoins)
        {
            Debug.Log("Quest Selesai! Semua koin telah dikumpulkan.");
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"Kumpulkan: {currentCoins}/{maxCoins} Coins";
        }
    }
    
    public void SpawnCoinBatch()
    {
        int amountToSpawn = Random.Range(1, 4);
        List<GameObject> inactiveCoins = coinPool.Where(c => !c.activeInHierarchy).ToList();
        List<Transform> availableSpawns = new List<Transform>(spawnPoints);

        for (int i = 0; i < amountToSpawn; i++)
        {
            if (inactiveCoins.Count == 0 || availableSpawns.Count == 0)
            {
                Debug.LogWarning("Tidak ada cukup koin atau spawn point yang tersedia untuk spawn!");
                return;
            }

            int coinIndex = Random.Range(0, inactiveCoins.Count);
            GameObject coinToSpawn = inactiveCoins[coinIndex];
            
            int spawnIndex = Random.Range(0, availableSpawns.Count);
            Transform spawnPoint = availableSpawns[spawnIndex];

            coinToSpawn.transform.position = spawnPoint.position;
            coinToSpawn.SetActive(true);

            inactiveCoins.RemoveAt(coinIndex);
            availableSpawns.RemoveAt(spawnIndex);
        }
    }

    // Fungsi ini dibutuhkan oleh LevelManager untuk mengecek jumlah koin saat ini
    public int GetCurrentCoins()
    {
        return currentCoins;
    }
}

