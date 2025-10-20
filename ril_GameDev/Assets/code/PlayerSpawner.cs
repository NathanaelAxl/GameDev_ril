using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
<<<<<<< HEAD
    // Start dipanggil sebelum frame pertama
    void Start()
    {
        // 1. Cari objek Player yang "abadi" di dalam scene
        GameObject player = GameObject.FindWithTag("Player");

        // 2. Cari objek titik spawn di dalam scene
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

        // 3. Jika keduanya ditemukan...
        if (player != null && spawnPoint != null)
        {
            // ...pindahkan posisi player ke posisi titik spawn.
=======
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

        if (player != null && spawnPoint != null)
        {
>>>>>>> nima
            player.transform.position = spawnPoint.transform.position;
            Debug.Log("Player berhasil di-spawn pada titik yang ditentukan!");
        }
        else
        {
<<<<<<< HEAD
            // Beri pesan error jika ada yang tidak ditemukan
=======
>>>>>>> nima
            if (player == null) Debug.LogError("Objek dengan Tag 'Player' tidak ditemukan!");
            if (spawnPoint == null) Debug.LogError("Objek dengan Tag 'SpawnPoint' tidak ditemukan di scene ini!");
        }
    }
}