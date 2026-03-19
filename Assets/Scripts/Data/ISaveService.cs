using Data;
using Settings;

namespace DefaultNamespace
{
    public interface ISaveService
    {
        void SaveSettingsData(SettingsController settingsController);
        void LoadSettingsData();
        void ResetSettingsData();
        void SavePlayerData(PlayerDataController playerDataController);
        void LoadPlayerData();
        void ResetPlayerData();
    }
}