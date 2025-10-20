#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("map1"); 
    }
    public void QuitGame()
    {
        Debug.Log("Tombol Quit ditekan!");

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        
        #else
        Application.Quit();
        #endif
    }
}

