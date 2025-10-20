using UnityEngine;
<<<<<<< HEAD
using UnityEngine.EventSystems; // Wajib ada untuk mendeteksi event UI

// Dengan IPointerUpHandler, script ini bisa langsung menerima event "pelepasan mouse"
public class UIButtonHandler : MonoBehaviour, IPointerUpHandler
{
    // Enum untuk memilih aksi tombol di Inspector
=======
using UnityEngine.EventSystems;

public class UIButtonHandler : MonoBehaviour, IPointerUpHandler
{
>>>>>>> nima
    public enum ButtonAction { Retry, Exit }

    [Tooltip("Pilih aksi yang akan dilakukan oleh tombol ini.")]
    public ButtonAction actionToPerform;

<<<<<<< HEAD
    // Fungsi ini akan dipanggil secara otomatis oleh EventSystem
    // saat tekanan mouse dilepaskan di atas objek ini.
=======
>>>>>>> nima
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"UIButtonHandler: OnPointerUp terdeteksi pada {gameObject.name}. Aksi: {actionToPerform}");

<<<<<<< HEAD
        // Pastikan instance GameOverTrigger ada
=======
>>>>>>> nima
        if (GameOverTrigger.instance == null)
        {
            Debug.LogError("Referensi ke GameOverTrigger.instance tidak ditemukan!");
            return;
        }

<<<<<<< HEAD
        // Jalankan aksi yang sesuai berdasarkan pilihan di Inspector
=======
>>>>>>> nima
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
