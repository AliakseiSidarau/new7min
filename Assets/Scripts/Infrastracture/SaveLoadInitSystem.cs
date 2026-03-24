using Infrastracture.SaveLoad.Progress;
using Zenject;

namespace Infrastracture
{
    public class SaveLoadInitSystem: IInitializable
    {
        private readonly IProgressService _progress;

        public SaveLoadInitSystem(IProgressService progress)
        {
            _progress = progress;
        }

        public void Initialize()
        {
            _progress.LoadProgressOrInitNew();
        }
    }
}