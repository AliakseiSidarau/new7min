using Data;
using Settings;

namespace DefaultNamespace
{
    public interface ISaveService
    {
        void SaveSettingsData(SettingsController settingsController);
        void LoadSettingsData();
        void SavePlayerData(PlayerDataController playerDataController);
        void LoadPlayerData();
    }
}