using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public static GameOverTrigger instance;

    [Header("UI Objects")]
    [Tooltip("Seret Panel/Objek utama dari UI Game Over ke sini.")]
    public GameObject gameOverScreen;

    private static bool isGameOver = false;

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

    private void Start()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void TriggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over terpicu oleh manajer!");
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RetryGame() 
    {
        Debug.Log("Tombol Retry ditekan! Mengulang scene...");
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() 
    {
        Debug.Log("Kembali ke Main Menu... Menghancurkan objek persisten.");

        Time.timeScale = 1f;

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Destroy(playerObject);
        }

        Destroy(this.gameObject);

        SceneManager.LoadScene("StartUI");
    }
}