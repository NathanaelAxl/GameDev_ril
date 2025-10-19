using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class CoinManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI coinText;
    [Header("Coin Settings")]
    public int maxCoins = 10;
    private int currentCoins = 0;
    [Header("Object Pool")]
    public List<GameObject> coinPool;
    [Header("Spawn Settings")]
    public List<Transform> spawnPoints;
    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        // Panggil ResetState di awal untuk setup pertama kali
        ResetState();
    }
    
    // --- PERBAIKAN ---
    // Diubah dari 'private' menjadi 'public' agar bisa dipanggil oleh SceneSetupManager
    public void ResetState()
    {
        Debug.Log("CoinManager: Mereset status koin.");
        currentCoins = 0;
        UpdateCoinText();

        foreach(var coin in coinPool)
        {
            if(coin != null) coin.SetActive(false);
        }
        
        SpawnCoinBatch();
    }
    
    public void CollectCoin()
    {
        currentCoins++;
        if (currentCoins > maxCoins) currentCoins = maxCoins;
        UpdateCoinText();
        LevelManager.instance?.CheckWinConditions();
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
        List<GameObject> inactiveCoins = coinPool.Where(c => c != null && !c.activeInHierarchy).ToList();
        List<Transform> availableSpawns = new List<Transform>(spawnPoints);

        for (int i = 0; i < amountToSpawn; i++)
        {
            if (inactiveCoins.Count == 0 || availableSpawns.Count == 0) return;
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
    
    public int GetCurrentCoins()
    {
        return currentCoins;
    }
}

