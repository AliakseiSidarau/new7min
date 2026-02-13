using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DefaultNamespace;
using Settings;
using UnityEngine;

namespace Data

{
    public class SaveService : ISaveService
    {
        private PlayerData _playerData;
        private SettingsData _settingsData;
        public void SaveSettingsData(SettingsController settingsController)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/data.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            SettingsData data = new SettingsData(settingsController);
            
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public void SavePlayerData(PlayerDataController playerDataController)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player_data.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData playerData = new PlayerData(playerDataController);
            
            formatter.Serialize(stream,playerData);
            stream.Close();
        }
        
        public void LoadSettingsData()
        {
            string path = Application.persistentDataPath + "/data.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SettingsData data = formatter.Deserialize(stream) as SettingsData;
                stream.Close();
                _settingsData = data;
                Debug.Log("Settings data successful loaded");
            }
            
            Debug.LogError("Settings data file not found in " + path);
            _settingsData = null;
        }

        public void LoadPlayerData()
        {
            string path = Application.persistentDataPath + "/player_data.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                _playerData = data;
            }
            
            Debug.LogError("Player data file not found in " + path);
            _playerData = null;
        }
    }
}