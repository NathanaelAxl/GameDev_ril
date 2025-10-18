using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Fungsi ini akan berjalan ketika ada objek lain yang masuk ke trigger
    private void OnTriggerEnter(Collider other)
    {
        // Cek jika yang menyentuh adalah objek dengan Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Panggil fungsi TriggerGameOver() dari manajer pusat
            GameOverTrigger.instance?.TriggerGameOver();
        }
    }
}
