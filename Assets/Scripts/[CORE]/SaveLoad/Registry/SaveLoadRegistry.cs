using System.Collections.Generic;
using Infrastracture.SaveLoad.Progress;
using Zenject;

namespace Infrastracture.SaveLoad
{
    public class SaveLoadRegistry: ISaveLoadRegistry
    {
        private readonly DiContainer _container;
        public SaveLoadRegistry(DiContainer container)
        {
            _container = container;
        }
        public IEnumerable<ISaveLoad> GetSaveLoadServices()
        {
            return _container.ResolveAll<ISaveLoad>();
        }
    }
}