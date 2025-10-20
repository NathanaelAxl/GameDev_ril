using UnityEngine;
using UnityEngine.EventSystems; // Wajib ada untuk mendeteksi event UI

// Dengan IPointerUpHandler, script ini bisa langsung menerima event "pelepasan mouse"
public class UIButtonHandler : MonoBehaviour, IPointerUpHandler
{
    // Enum untuk memilih aksi tombol di Inspector
    public enum ButtonAction { Retry, Exit }

    [Tooltip("Pilih aksi yang akan dilakukan oleh tombol ini.")]
    public ButtonAction actionToPerform;

    // Fungsi ini akan dipanggil secara otomatis oleh EventSystem
    // saat tekanan mouse dilepaskan di atas objek ini.
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"UIButtonHandler: OnPointerUp terdeteksi pada {gameObject.name}. Aksi: {actionToPerform}");

        // Pastikan instance GameOverTrigger ada
        if (GameOverTrigger.instance == null)
        {
            Debug.LogError("Referensi ke GameOverTrigger.instance tidak ditemukan!");
            return;
        }

        // Jalankan aksi yang sesuai berdasarkan pilihan di Inspector
        switch (actionToPerform)
        {
            case ButtonAction.Retry:
                GameOverTrigger.instance.RetryGame();
                break;
            case ButtonAction.Exit:
                GameOverTrigger.instance.ExitGame();
                break;
        }
    }
}
