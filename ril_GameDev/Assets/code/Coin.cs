using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("Waktu dalam detik sebelum koin hilang jika tidak diambil.")]
    public float lifetime = 10.0f; 
    private float lifeTimer;

    // OnEnable dipanggil setiap kali objek ini diaktifkan di scene
    private void OnEnable()
    {
        // Reset timer setiap kali koin muncul/diaktifkan
        lifeTimer = lifetime;
    }

    void Update()
    {
        // Hitung mundur timer setiap frame
        lifeTimer -= Time.deltaTime;

        // Jika waktu habis, nonaktifkan koin dan minta manager untuk spawn batch baru
        if (lifeTimer <= 0)
        {
            // Beritahu manager (jika ada) untuk memunculkan koin baru
            CoinManager.instance?.SpawnCoinBatch();
            
            // Nonaktifkan objek koin ini
            gameObject.SetActive(false);
        }
    }

    // OnTriggerEnter akan berjalan ketika ada objek lain yang masuk ke dalam collider trigger koin ini
    private void OnTriggerEnter(Collider other)
    {
        // Pertama, kita cek apakah objek yang menyentuh memiliki Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Jika benar itu Player, panggil fungsi CollectCoin dari CoinManager
            CoinManager.instance?.CollectCoin();
            
            // Minta manager untuk memunculkan batch koin baru
            CoinManager.instance?.SpawnCoinBatch();

            // Nonaktifkan objek koin ini agar bisa digunakan lagi nanti (object pooling)
            gameObject.SetActive(false);
        }
    }
}