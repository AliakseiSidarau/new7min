using System.Collections.Generic;

namespace Infrastracture.SaveLoad.Progress
{
    public interface ISaveLoadRegistry
    {
        IEnumerable<ISaveLoad> GetSaveLoadServices();
    }
}