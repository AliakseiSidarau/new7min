using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
}