using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class UIMessageManager : MonoBehaviour
{
    public static UIMessageManager instance;

    [Header("UI Components")]
    [Tooltip("Panel utama yang menampung semua elemen.")]
    public GameObject messagePanel;
    [Tooltip("Canvas Group dari panel utama.")]
    public CanvasGroup messageCanvasGroup;
    [Tooltip("Komponen Text untuk pesan.")]
    public TextMeshProUGUI messageText;
    [Tooltip("Komponen Image di dalam panel (opsional).")]
    public Image displayImage;

    [Header("Timing Settings")]
    public float fadeInTime = 0.5f;
    public float displayTime = 2.0f;
    // fadeOutTime tidak lagi digunakan, tapi bisa dibiarkan
    public float fadeOutTime = 0.5f; 

    public float TotalDisplayDuration => fadeInTime + displayTime + fadeOutTime;
    private Coroutine displayCoroutine;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if(messagePanel != null) messagePanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (displayCoroutine != null) StopCoroutine(displayCoroutine);
        displayCoroutine = StartCoroutine(DisplayCoroutine(message, null));
    }

    public void ShowImage(Sprite imageToShow)
    {
        if (displayCoroutine != null) StopCoroutine(displayCoroutine);
        displayCoroutine = StartCoroutine(DisplayCoroutine("", imageToShow));
    }

    private IEnumerator DisplayCoroutine(string message, Sprite image)
    {
        // 1. Aktifkan panel
        if(messagePanel == null || messageCanvasGroup == null) yield break;
        messagePanel.SetActive(true);

        // 2. Pilih Mode: Teks atau Gambar
        if (image != null && displayImage != null)
        {
            if(messageText != null) messageText.gameObject.SetActive(false);
            displayImage.gameObject.SetActive(true);
            displayImage.sprite = image;
            Color imgColor = displayImage.color;
            imgColor.a = 1f;
            displayImage.color = imgColor;
        }
        else if (messageText != null)
        {
            if(displayImage != null) displayImage.gameObject.SetActive(false);
            messageText.gameObject.SetActive(true);
            messageText.text = message;
        }
        else
        {
             messagePanel.SetActive(false);
            yield break;
        }

        // 3. FADE IN
        float timer = 0f;
        while (timer < fadeInTime)
        {
            messageCanvasGroup.alpha = timer / fadeInTime;
            timer += Time.deltaTime;
            yield return null;
        }
        messageCanvasGroup.alpha = 1f;

        // 4. DISPLAY
        yield return new WaitForSeconds(displayTime);

        // --- PERBAIKAN: HAPUS FADE-OUT, LANGSUNG DISABLE ---
        // 5. Langsung set alpha ke 0 dan nonaktifkan panel.
        messageCanvasGroup.alpha = 0f;
        messagePanel.SetActive(false);
    }
}