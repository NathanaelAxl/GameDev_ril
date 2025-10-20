using UnityEngine;
using TMPro;

public class KeyManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI keyText;

    [Header("Game Object")]
    [Tooltip("Seret objek Key dari scene ke sini agar bisa diaktifkan kembali.")]
    public GameObject keyObject;

    private bool hasKey = false;
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
        ResetState();
    }

    public void ResetState()
    {
        Debug.Log("KeyManager: Mereset status kunci.");
        hasKey = false;
        UpdateKeyText();

        if(keyObject != null)
        {
            keyObject.SetActive(true);
        }
    }
    
    public void CollectKey()
    {
        if (!hasKey)
        {
            hasKey = true;
            UpdateKeyText();
            Debug.Log("Kunci telah didapatkan!");
            LevelManager.instance?.CheckWinConditions();
        }
    }

    void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = hasKey ? "Kumpulkan Kunci: 1/1" : "Kumpulkan Kunci: 0/1";
        }
    }
    
    public bool HasKey()
    {
        return hasKey;
    }
}