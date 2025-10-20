using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetupManager : MonoBehaviour
{
    private static bool isFirstLoad = true;

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
        GameObject player = GameObject.FindWithTag("Player");
        GameObject startPoint = GameObject.FindWithTag("StartPoint");
        if (player != null && startPoint != null)
        {
            player.transform.position = startPoint.transform.position;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        CoinManager.instance?.ResetState();
        KeyManager.instance?.ResetState();
        
        if (UIMessageManager.instance != null)
        {
            if (scene.name == "map1" && isFirstLoad)
            {
                UIMessageManager.instance.ShowMessage("Welcome to Our game");
                isFirstLoad = false;
            }
            else if (scene.name == "map2")
            {
                UIMessageManager.instance.ShowMessage("Welcome to level 2");
            }
        }
    }
}