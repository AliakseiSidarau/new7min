using Infrastracture.SaveLoad.Data;
using UnityEngine;

namespace Infrastracture.SaveLoad.Progress
{
    public class ProgressService: IProgressService
    {
        public const string ProgressKey = "Progress";
        public PlayerProgress Progress { get; private set; }
        
        public bool HasLoadProgress { get; private set; }

        public PlayerProgress CreateNewProgress()
        {
            HasLoadProgress = false;
            return Progress = new PlayerProgress();
        }

        public void SaveProgress()
        {
            string json = JsonUtility.ToJson(Progress);
            Debug.Log("PlayerPrefs saving JSON: " + json);
            PlayerPrefs.SetString(ProgressKey, json);
            PlayerPrefs.Save();
            // PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(Progress));
            // PlayerPrefs.Save();
            
        }

        public PlayerProgress LoadProgressOrInitNew()
        {
            var json = PlayerPrefs.GetString(ProgressKey, string.Empty);
            Debug.Log($"Progress json from prefs: {json}");

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogError("No progress data found");
                return CreateNewProgress();
            }

            Debug.LogWarning("Load progress data");
            HasLoadProgress = true;
            Progress = JsonUtility.FromJson<PlayerProgress>(json);
            
            if (Progress.SettingsData == null)
            {
                Debug.LogWarning("SettingsData was null → creating new");
                Progress.SettingsData = new SettingsData();
            }
            Debug.Log($"Loaded Progress: {JsonUtility.ToJson(Progress)}");
            return Progress;
        }
    }
}