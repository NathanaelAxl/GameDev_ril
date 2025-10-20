using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour
{
    public enum PortalType { GoToNextLevel, ReturnToMainMenu }

    [Header("Portal Settings")]
    public PortalType portalBehavior;
    public string nextSceneName;

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated || !other.CompareTag("Player")) return;
        
        isActivated = true;

        switch (portalBehavior)
        {
            case PortalType.GoToNextLevel:
                SceneManager.LoadScene(nextSceneName);
                break;

            case PortalType.ReturnToMainMenu:
                StartCoroutine(WinSequence(other.gameObject));
                break;
        }
    }

    private IEnumerator WinSequence(GameObject playerObject)
    {
        Rigidbody playerRb = playerObject.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.isKinematic = true;
            Debug.Log("Fisika pemain dibekukan.");
        }

        if (UIMessageManager.instance != null)
        {
            UIMessageManager.instance.ShowMessage("You Winn");
            
            float waitTime = UIMessageManager.instance.fadeInTime + 
                             UIMessageManager.instance.displayTime + 
                             UIMessageManager.instance.fadeOutTime;
            
            yield return new WaitForSecondsRealtime(waitTime);
        }

        Time.timeScale = 1f;
        if (playerObject != null) Destroy(playerObject);
        if (GameOverTrigger.instance != null) Destroy(GameOverTrigger.instance.gameObject);
        SceneManager.LoadScene(nextSceneName);
    }
}