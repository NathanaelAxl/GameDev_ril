using UnityEngine;
using UnityEngine.EventSystems; // Wajib ada untuk mendeteksi klik UI

// Dengan 'IPointerClickHandler', script ini bisa langsung menerima event klik
public class RetryButtonHandler : MonoBehaviour, IPointerClickHandler
{
    // Fungsi ini akan dipanggil secara otomatis oleh EventSystem
    // saat objek ini diklik. Ini lebih handal daripada OnClick di Inspector.
    public void OnPointerClick(PointerEventData eventData)
    {
        // Cek apakah instance GameOverTrigger ada
        if (GameOverTrigger.instance != null)
        {
            // Panggil fungsi RetryGame() secara langsung dari manajer pusat
            GameOverTrigger.instance.RetryGame();
        }
        else
        {
            Debug.LogError("Referensi ke GameOverTrigger tidak ditemukan!");
        }
    }
}
