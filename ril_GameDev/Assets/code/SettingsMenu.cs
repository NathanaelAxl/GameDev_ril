using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    // --- BARU: Saklar global untuk status jeda ---
    public static bool isGamePaused = false;

    [Header("UI Components")]
    public GameObject settingsPanel;

    private bool isMenuOpen = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    // --- BARU: Pastikan game tidak dalam status jeda saat dimulai ---
    private void Start()
    {
        isGamePaused = false;
    }

    public void ToggleSettingsMenu()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }

    private void OpenMenu()
    {
        isMenuOpen = true;
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
        
        // --- BARU: Nyalakan saklar jeda ---
        isGamePaused = true; 
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        
        // --- BARU: Matikan saklar jeda ---
        isGamePaused = false; 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
        // --- BARU: Pastikan saklar jeda mati sebelum pindah scene ---
        isGamePaused = false; 
        
        Time.timeScale = 1f;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Destroy(playerObject);
        }
        if (GameOverTrigger.instance != null)
        {
            Destroy(GameOverTrigger.instance.gameObject);
        }
        if (this != null) Destroy(this.gameObject);
        SceneManager.LoadScene("StartUI");
    }
}