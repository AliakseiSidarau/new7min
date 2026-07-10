using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Progress;
using Sound;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class ProjectInstaller: MonoInstaller
    {
        [SerializeField] private AudioService _audioServicePrefab;
        public override void InstallBindings()
        {
            BindProgressService();
            BindSaveLoad();
            BindAudioService();
        }

        void BindSaveLoad()
        {
            Container.Bind<ISaveLoadRegistry>()
                .To<SaveLoadRegistry>()
                .AsSingle();

            Container.Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        void BindProgressService()
        {
            Container.Bind<IProgressService>()
                .To<ProgressService>()
                .AsSingle();
        }

        void BindAudioService()
        {
            Container.BindInterfacesTo<AudioService>()
                .FromComponentInNewPrefab(_audioServicePrefab)
                .UnderTransformGroup("Audio")
                .AsSingle()
                .NonLazy();
        }
    }
}