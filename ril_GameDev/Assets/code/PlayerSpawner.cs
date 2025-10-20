using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
            Debug.Log("Player berhasil di-spawn pada titik yang ditentukan!");
        }
        else
        {
            if (player == null) Debug.LogError("Objek dengan Tag 'Player' tidak ditemukan!");
            if (spawnPoint == null) Debug.LogError("Objek dengan Tag 'SpawnPoint' tidak ditemukan di scene ini!");
        }
    }
}