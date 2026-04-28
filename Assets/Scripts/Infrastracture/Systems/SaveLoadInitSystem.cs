using Infrastracture.SaveLoad.Progress;
using Zenject;

namespace Infrastracture
{
    public class SaveLoadInitSystem: IInitializable
    {
        private readonly IProgressDataService _progressData;

        public SaveLoadInitSystem(IProgressDataService progressData)
        {
            _progressData = progressData;
        }

        public void Initialize()
        {
            _progressData.LoadProgressOrInitNew();
        }
    }
}