using Infrastracture.SaveLoad.Progress;
using UnityEngine;

namespace Infrastracture.SaveLoad
{
    public class SaveLoadService: ISaveLoadService
    {
        private readonly IProgressDataService _progressData;
        private readonly ISaveLoadRegistry _registry;

        public SaveLoadService(IProgressDataService progressData, ISaveLoadRegistry registry)
        {
            _progressData = progressData;
            _registry = registry;
        }

        public void Save()
        {
            foreach (ISaveLoad saveLoad in _registry.GetSaveLoadServices())
            {
                saveLoad.Save(_progressData.Progress);
            }
            Debug.Log("Saving Progress to PlayerPrefs...");
            _progressData.SaveProgress();
        }

        public void Load()
        {
            if (_progressData.HasLoadProgress)
            {
                foreach (ISaveLoad saveLoad in _registry.GetSaveLoadServices())
                {
                    saveLoad.Load(_progressData.Progress);
                }
            }
            else
            {
                Debug.LogWarning("No Actual ProgressData");
            }
        }

        public void Reset()
        {
            
        }
    }
}