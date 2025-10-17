using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("map 1");
    }

    // Fungsi ini akan kita panggil saat tombol "Quit" diklik
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}