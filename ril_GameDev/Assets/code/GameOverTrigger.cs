using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    // Ganti nama script menjadi GameOverTrigger jika Anda ingin mengganti yang lama
    public static GameOverTrigger instance;

    [Header("UI")]
    public GameObject gameOverUIObject;
    public GameObject retryButton;
    public GameObject exitButton;

    private void Awake()
    {
        Debug.Log("GameOverTrigger: Awake() - Mencoba set instance.");
        if (instance == null)
        {
            instance = this;
            Debug.Log("GameOverTrigger: Awake() - Instance BERHASIL di-set.");
        }
        else
        {
            Debug.LogWarning("GameOverTrigger: Awake() - Instance sudah ada! Menghancurkan duplikat.");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameOverUIObject != null) gameOverUIObject.SetActive(false);
        if (retryButton != null) retryButton.SetActive(false);
        if (exitButton != null) exitButton.SetActive(false);
    }
    
    public void TriggerGameOver()
    {
        Debug.Log("Fungsi TriggerGameOver() dipanggil.");
        if (gameOverUIObject != null) gameOverUIObject.SetActive(true);
        if (retryButton != null) retryButton.SetActive(true);
        if (exitButton != null) exitButton.SetActive(true);
        Time.timeScale = 0.0001f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryGame()
    {
        Debug.Log("--- DEEP DEBUG (3/3): RetryGame() di dalam GameOverTrigger BERHASIL dipanggil! ---");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // DEEP DEBUG: Langkah terakhir, konfirmasi fungsi ini terpanggil.
        Debug.Log("--- DEEP DEBUG (3/3): ExitGame() di dalam GameOverTrigger BERHASIL dipanggil! ---");
    }
}
