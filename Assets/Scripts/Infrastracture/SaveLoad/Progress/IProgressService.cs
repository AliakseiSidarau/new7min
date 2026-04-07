using Infrastracture.SaveLoad.Data;

namespace Infrastracture.SaveLoad.Progress
{
    public interface IProgressService
    {
        PlayerProgress Progress { get; }
        bool HasLoadProgress { get; }
        PlayerProgress CreateNewProgress();
        void SaveProgress();
        PlayerProgress LoadProgressOrInitNew();
    }
}