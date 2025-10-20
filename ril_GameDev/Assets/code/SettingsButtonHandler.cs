using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsButtonHandler : MonoBehaviour, IPointerUpHandler
{
    public enum SettingsAction { ToggleMenu, CloseMenu, GoToMainMenu }

    [Tooltip("Pilih aksi yang akan dilakukan oleh tombol ini.")]
    public SettingsAction actionToPerform;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (SettingsMenu.instance == null)
        {
            Debug.LogError("Referensi ke SettingsMenu.instance tidak ditemukan!");
            return;
        }

        switch (actionToPerform)
        {
            case SettingsAction.ToggleMenu:
                SettingsMenu.instance.ToggleSettingsMenu();
                break;
            case SettingsAction.CloseMenu:
                SettingsMenu.instance.CloseMenu();
                break;
            case SettingsAction.GoToMainMenu:
                SettingsMenu.instance.GoToMainMenu();
                break;
        }
    }
}