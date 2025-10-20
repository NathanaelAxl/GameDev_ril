using UnityEngine;

public class Coin : MonoBehaviour
{
<<<<<<< HEAD
    // Fungsi ini akan berjalan ketika ada objek lain yang masuk ke trigger koin
    private void OnTriggerEnter(Collider other)
    {
        // Cek jika yang menyentuh adalah objek dengan Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Beri tahu CoinManager bahwa sebuah koin telah diambil
            CoinManager.instance?.CollectCoin();
            
            // Hancurkan objek koin ini secara permanen dari scene
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.instance?.CollectCoin();
            
>>>>>>> nima
            Destroy(gameObject);
        }
    }
}