using Infrastracture.SaveLoad.Data;

namespace Infrastracture.SaveLoad.Progress
{
    public interface IProgressDataService
    {
        PlayerProgress Progress { get; }
        bool HasLoadProgress { get; }
        PlayerProgress CreateNewProgress();
        void SaveProgress();
        PlayerProgress LoadProgressOrInitNew();
    }
}