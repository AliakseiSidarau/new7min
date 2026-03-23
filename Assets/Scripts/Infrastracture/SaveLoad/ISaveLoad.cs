using Infrastracture.SaveLoad.Data;

namespace Infrastracture.SaveLoad
{
    public interface ISaveLoad
    {
        void Save(PlayerProgress progress);
        void Load(PlayerProgress progress);
        void Reset(PlayerProgress progress);
    }
}