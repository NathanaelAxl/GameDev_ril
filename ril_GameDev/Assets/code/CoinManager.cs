using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI coinText;

    private int maxCoins;
    private int currentCoins = 0;
    
    public static CoinManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "map1") 
        {
            ResetState();
        }
    }
    
    public void ResetState()
    {
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        currentCoins = 0;
        
        UpdateCoinText();
        Debug.Log("CoinManager di-reset. Ditemukan " + maxCoins + " koin di level ini.");
    }

    public void CollectCoin()
    {
        currentCoins++;
        UpdateCoinText();

        LevelManager.instance?.CheckWinConditions();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"Kumpulkan: {currentCoins}/{maxCoins} Coins";
        }
    }
    
    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public int GetMaxCoins()
    {
        return maxCoins;
    }
}