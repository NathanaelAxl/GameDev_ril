using UnityEngine;
using UnityEngine.EventSystems; // Wajib ada untuk mendeteksi klik UI

public class ExitButtonHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameOverTrigger.instance != null)
        {
            // Panggil fungsi ExitGame() secara langsung dari manajer pusat
            GameOverTrigger.instance.ExitGame();
        }
        else
        {
            Debug.LogError("Referensi ke GameOverTrigger tidak ditemukan!");
        }
    }
}
