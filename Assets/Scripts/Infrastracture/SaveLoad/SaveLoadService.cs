using Infrastracture.SaveLoad.Progress;
using UnityEngine;

namespace Infrastracture.SaveLoad
{
    public class SaveLoadService: ISaveLoadService
    {
        private readonly IProgressService _progress;
        private readonly ISaveLoadRegistry _registry;

        public SaveLoadService(IProgressService progress, ISaveLoadRegistry registry)
        {
            _progress = progress;
            _registry = registry;
        }

        public void Save()
        {
            foreach (ISaveLoad saveLoad in _registry.GetSaveLoadServices())
            {
                saveLoad.Save(_progress.Progress);
            }
            Debug.Log("Saving Progress to PlayerPrefs...");
            _progress.SaveProgress();
        }

        public void Load()
        {
            if (_progress.HasLoadProgress)
            {
                foreach (ISaveLoad saveLoad in _registry.GetSaveLoadServices())
                {
                    saveLoad.Load(_progress.Progress);
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