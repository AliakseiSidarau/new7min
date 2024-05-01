using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Data;
using Settings;
using UnityEngine;

namespace DefaultNamespace

{
    public static class SaveSystem
    {
        public static void SaveSettings(SettingsController settingsController)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/data.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            SettingsData data = new SettingsData(settingsController);
            
            formatter.Serialize(stream, data);
            stream.Close();
            
        }

        public static void SavePlayerData(PlayerDataController playerDataController)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player_data.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData playerData = new PlayerData(playerDataController);
            
            formatter.Serialize(stream,playerData);
            stream.Close();
        }

        public static SettingsData LoadSettings()
        {
            string path = Application.persistentDataPath + "/data.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SettingsData data = formatter.Deserialize(stream) as SettingsData;
                stream.Close();
                
                return data;
            }
            
            Debug.LogError("Settings data file not found in " + path);
            return null;
        }

        public static PlayerData LoadPlayerData()
        {
            string path = Application.persistentDataPath + "/player_data.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
                stream.Close();

                return playerData;
            }
            
            Debug.LogError("Player data file not found in " + path);
            return null;
        }
    }
}