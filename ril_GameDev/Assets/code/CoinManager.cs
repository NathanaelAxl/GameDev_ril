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

    // Fungsi utama untuk memunculkan koin secara acak
    public void SpawnCoinBatch()
    {
        // 1. Tentukan berapa banyak koin yang akan di-spawn (antara 1 sampai 3)
        int amountToSpawn = Random.Range(1, 4); // Angka 4 eksklusif, jadi hasilnya 1, 2, atau 3

        // 2. Ambil daftar koin dari pool yang saat ini sedang tidak aktif
        List<GameObject> inactiveCoins = coinPool.Where(c => !c.activeInHierarchy).ToList();

        // 3. Buat salinan daftar spawn point agar kita bisa menghapusnya sementara
        List<Transform> availableSpawns = new List<Transform>(spawnPoints);

        // 4. Lakukan perulangan sebanyak jumlah koin yang akan di-spawn
        for (int i = 0; i < amountToSpawn; i++)
        {
            // Pastikan masih ada koin dan spawn point yang tersedia
            if (inactiveCoins.Count == 0 || availableSpawns.Count == 0)
            {
                Debug.LogWarning("Tidak ada cukup koin atau spawn point yang tersedia untuk spawn!");
                return; // Keluar dari fungsi jika tidak bisa spawn lagi
            }

            // Pilih koin acak dari yang tidak aktif
            int coinIndex = Random.Range(0, inactiveCoins.Count);
            GameObject coinToSpawn = inactiveCoins[coinIndex];

            // Pilih spawn point acak dari yang tersedia
            int spawnIndex = Random.Range(0, availableSpawns.Count);
            Transform spawnPoint = availableSpawns[spawnIndex];

            // Pindahkan posisi koin dan aktifkan
            coinToSpawn.transform.position = spawnPoint.position;
            coinToSpawn.SetActive(true);

            // Hapus dari daftar sementara agar tidak dipilih lagi di batch yang sama
            inactiveCoins.RemoveAt(coinIndex);
            availableSpawns.RemoveAt(spawnIndex);
        }
    }
}