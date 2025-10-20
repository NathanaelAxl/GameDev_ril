using UnityEngine;

public class Key : MonoBehaviour
{
<<<<<<< HEAD
    // OnTriggerEnter akan berjalan ketika ada objek lain yang masuk ke dalam collider trigger kunci ini
    private void OnTriggerEnter(Collider other)
    {
        // Pertama, kita cek apakah objek yang menyentuh memiliki Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Jika benar itu Player, panggil fungsi CollectKey dari KeyManager
            // Tanda tanya (?) adalah null-check, memastikan instance KeyManager ada sebelum memanggil fungsi
            KeyManager.instance?.CollectKey();

            // Setelah kunci diambil, nonaktifkan objek kunci ini agar hilang dari scene
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyManager.instance?.CollectKey();

>>>>>>> nima
            gameObject.SetActive(false);
        }
    }
}
