using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

<<<<<<< HEAD
    // --- BARU: Saklar global untuk status jeda ---
=======
>>>>>>> nima
    public static bool isGamePaused = false;

    [Header("UI Components")]
    public GameObject settingsPanel;

    private bool isMenuOpen = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
<<<<<<< HEAD
    // --- BARU: Pastikan game tidak dalam status jeda saat dimulai ---
=======
>>>>>>> nima
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
        
<<<<<<< HEAD
        // --- BARU: Nyalakan saklar jeda ---
=======
>>>>>>> nima
        isGamePaused = true; 
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        
<<<<<<< HEAD
        // --- BARU: Matikan saklar jeda ---
=======
>>>>>>> nima
        isGamePaused = false; 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
<<<<<<< HEAD
        // --- BARU: Pastikan saklar jeda mati sebelum pindah scene ---
=======
>>>>>>> nima
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