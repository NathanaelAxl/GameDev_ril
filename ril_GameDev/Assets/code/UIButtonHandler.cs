using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHandler : MonoBehaviour, IPointerUpHandler
{
    public enum ButtonAction { Retry, Exit }

    [Tooltip("Pilih aksi yang akan dilakukan oleh tombol ini.")]
    public ButtonAction actionToPerform;

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"UIButtonHandler: OnPointerUp terdeteksi pada {gameObject.name}. Aksi: {actionToPerform}");

        if (GameOverTrigger.instance == null)
        {
            Debug.LogError("Referensi ke GameOverTrigger.instance tidak ditemukan!");
            return;
        }

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
