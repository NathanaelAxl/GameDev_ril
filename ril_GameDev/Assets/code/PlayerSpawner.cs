using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
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
            player.transform.position = spawnPoint.transform.position;
            Debug.Log("Player berhasil di-spawn pada titik yang ditentukan!");
        }
        else
        {
            // Beri pesan error jika ada yang tidak ditemukan
            if (player == null) Debug.LogError("Objek dengan Tag 'Player' tidak ditemukan!");
            if (spawnPoint == null) Debug.LogError("Objek dengan Tag 'SpawnPoint' tidak ditemukan di scene ini!");
        }
    }
}