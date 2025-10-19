using UnityEngine;
using UnityEngine.EventSystems; // Wajib ada untuk UI Events

// Script ini akan melaporkan setiap interaksi dasar yang diterima dari EventSystem
public class ButtonDebugTracer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    // Dipanggil saat tombol DITEKAN
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"<color=yellow>[BUTTON TRACER] OnPointerDown terdeteksi pada objek: {gameObject.name}</color>");
    }

    // --- PERBAIKAN UTAMA ---
    // Logika dipindahkan ke sini karena OnPointerUp lebih andal saat Time.timeScale = 0
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"<color=yellow>[BUTTON TRACER] OnPointerUp terdeteksi pada objek: {gameObject.name}. Memanggil fungsi dari sini!</color>");

        // Coba panggil manajer secara manual dari sini
        if (gameObject.name.Contains("retry")) // Dibuat case-insensitive untuk keamanan
        {
            GameOverTrigger_SuperDebug.instance?.RetryGame();
        }
        else if (gameObject.name.Contains("exit")) // Dibuat case-insensitive untuk keamanan
        {
            GameOverTrigger_SuperDebug.instance?.ExitGame();
        }
    }

    // Fungsi ini terbukti tidak andal saat time scale = 0, jadi kita biarkan kosong.
    public void OnPointerClick(PointerEventData eventData)
    {
        // Logika sudah dipindahkan ke OnPointerUp
        // Debug.Log($"<color=lime>[BUTTON TRACER] OnPointerClick (KLIK VALID) terdeteksi pada objek: {gameObject.name}!</color>");
    }
}

