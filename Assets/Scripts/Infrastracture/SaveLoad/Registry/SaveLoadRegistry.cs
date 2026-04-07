using System;
using System.Collections.Generic;
using Infrastracture.SaveLoad.Progress;

namespace Infrastracture.SaveLoad
{
    public class SaveLoadRegistry: ISaveLoadRegistry
    {
        private readonly IDiService _di;
        public SaveLoadRegistry(IDiService di)
        {
            _di = di;
        }
        public IEnumerable<ISaveLoad> GetSaveLoadServices()
        {
            return _di.ResolveAll<ISaveLoad>();
        }
    }
}