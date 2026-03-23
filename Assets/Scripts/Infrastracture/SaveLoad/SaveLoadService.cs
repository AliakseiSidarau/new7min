using Infrastracture.SaveLoad.Progress;

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
            
        }

        public void Load()
        {
            
        }

        public void Reset()
        {
            
        }
    }
}