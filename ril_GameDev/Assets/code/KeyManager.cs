using UnityEngine;
using TMPro;

public class KeyManager : MonoBehaviour
{
    [Header("UI Components")]
    [Tooltip("Seret objek Text (TMP) untuk kunci ke sini.")]
    public TextMeshProUGUI keyText;

    private bool hasKey = false;

    // Singleton pattern agar mudah diakses dari script lain
    public static KeyManager instance;

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
        // Atur teks awal saat permainan dimulai
        UpdateKeyText();
    }

    // Fungsi ini akan dipanggil oleh script Key.cs saat kunci disentuh
    public void CollectKey()
    {
        // Cek jika kunci belum dimiliki untuk mencegah fungsi berjalan berkali-kali
        if (!hasKey)
        {
            hasKey = true;
            UpdateKeyText();
            Debug.Log("Kunci telah didapatkan!");

            // Beri tahu LevelManager untuk memeriksa kondisi menang
            LevelManager.instance?.CheckWinConditions();
        }
    }

    void UpdateKeyText()
    {
        if (keyText != null)
        {
            if (hasKey)
            {
                keyText.text = "Kumpulkan Kunci: 1/1";
            }
            else
            {
                keyText.text = "Kumpulkan Kunci: 0/1";
            }
        }
    }
    
    // Fungsi ini dibutuhkan oleh LevelManager untuk mengecek status kunci
    public bool HasKey()
    {
        return hasKey;
    }
}