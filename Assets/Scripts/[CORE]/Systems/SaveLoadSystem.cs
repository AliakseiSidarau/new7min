using Infrastracture.SaveLoad;
using Zenject;

namespace Infrastracture
{
    public class SaveLoadSystem: IInitializable
    {
        private readonly ISaveLoadService _saveLoad;
        
        public SaveLoadSystem(ISaveLoadService saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void Initialize()
        {
            _saveLoad.Load();
        }
    }
}