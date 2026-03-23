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
            PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(Progress));
        }

        public PlayerProgress LoadProgressOrInitNew()
        {
            var json = PlayerPrefs.GetString(ProgressKey);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogError("No progress data found");
                return CreateNewProgress();
            }
            else
            {
                Debug.LogWarning("Load progress data");
                HasLoadProgress = true;
                Progress = JsonUtility.FromJson<PlayerProgress>(json);
                return Progress;
            }
        }
    }
}