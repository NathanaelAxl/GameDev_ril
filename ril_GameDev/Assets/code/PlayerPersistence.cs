using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    // Membuat instance tunggal dari objek ini
    public static PlayerPersistence instance;

    private void Awake()
    {
        // Ini adalah pola Singleton.
        // Jika belum ada instance...
        if (instance == null)
        {
            // ...maka jadikan objek ini sebagai instance utama.
            instance = this;
            // Jangan hancurkan objek ini saat berpindah scene.
            DontDestroyOnLoad(gameObject);
        }
        // Jika sudah ada instance lain (misalnya saat kembali ke menu utama)...
        else
        {
            // ...maka hancurkan objek duplikat ini.
            Destroy(gameObject);
        }
    }
}