using UnityEngine;
using UnityEngine.EventSystems; // Wajib ada untuk mendeteksi event UI

public class SettingsButtonHandler : MonoBehaviour, IPointerUpHandler
{
    // Enum untuk memilih aksi yang akan dilakukan oleh tombol ini
    public enum SettingsAction { ToggleMenu, CloseMenu, GoToMainMenu }

    [Tooltip("Pilih aksi yang akan dilakukan oleh tombol ini.")]
    public SettingsAction actionToPerform;

    // Fungsi ini akan dipanggil secara otomatis oleh EventSystem
    // saat tekanan mouse dilepaskan di atas objek ini.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Pastikan instance SettingsMenu ada
        if (SettingsMenu.instance == null)
        {
            Debug.LogError("Referensi ke SettingsMenu.instance tidak ditemukan!");
            return;
        }

        // Jalankan aksi yang sesuai berdasarkan pilihan di Inspector
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