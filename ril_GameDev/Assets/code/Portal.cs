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
                // --- PERBAIKAN: Kirim informasi pemain ke coroutine ---
                StartCoroutine(WinSequence(other.gameObject));
                break;
        }
    }

    // --- PERBAIKAN: Coroutine sekarang menerima objek pemain ---
    private IEnumerator WinSequence(GameObject playerObject)
    {
        // --- LANGKAH KUNCI: Bekukan pemain ---
        Rigidbody playerRb = playerObject.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            // Menghentikan semua momentum
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            // Membuat pemain kebal terhadap fisika (seperti gravitasi)
            playerRb.isKinematic = true;
            Debug.Log("Fisika pemain dibekukan.");
        }

        // 1. Tampilkan pesan kemenangan
        if (UIMessageManager.instance != null)
        {
            UIMessageManager.instance.ShowMessage("You Winn");
            
            float waitTime = UIMessageManager.instance.fadeInTime + 
                             UIMessageManager.instance.displayTime + 
                             UIMessageManager.instance.fadeOutTime;
            
            yield return new WaitForSecondsRealtime(waitTime);
        }

        // 2. Setelah menunggu, baru lakukan cleanup dan pindah scene
        Time.timeScale = 1f;
        // Kita sudah punya referensi ke playerObject, jadi tidak perlu mencarinya lagi
        if (playerObject != null) Destroy(playerObject);
        if (GameOverTrigger.instance != null) Destroy(GameOverTrigger.instance.gameObject);
        
        SceneManager.LoadScene(nextSceneName);
    }
}