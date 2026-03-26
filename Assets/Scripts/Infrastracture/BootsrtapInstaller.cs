using System;
using Data;
using DefaultNamespace;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Progress;
using Scenes;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastracture
{
    public class BootsrtapInstaller: MonoInstaller
    {
        [SerializeField] private AudioService _audioServicePrefab;
        public override void InstallBindings()
        {
            DiServiceBiding();
            AudioServiceBiding();
            SaveLoadServiceBiding();
            // SaveServiceBiding();
            SceneManagerServiceBiding();
            BootstrapInitializeSystemBiding();
        }

        void BootstrapInitializeSystemBiding()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInitializeSystem>()
                .AsSingle();
            
            Debug.Log("Bootstrap biding was finished!");
        }

        void SaveServiceBiding()
        {
            Container.BindInterfacesAndSelfTo<SaveService>()
                .AsSingle()
                .NonLazy();
            
            Debug.Log("SaveService biding was finished!");
        }

        void SceneManagerServiceBiding()
        {
            Container.BindInterfacesAndSelfTo<SceneManagerService>()
                .AsSingle()
                .NonLazy();
        }

        void AudioServiceBiding()
        {
            Container.BindInterfacesTo<AudioService>()
                .FromComponentInNewPrefab(_audioServicePrefab)
                .UnderTransformGroup("Audio")
                .AsSingle()
                .NonLazy();
            
            Debug.Log("AudioService biding was finished!");
        }

        void SaveLoadServiceBiding()
        {
            Container.Bind<IProgressService>().To<ProgressService>()
                .AsSingle();
            Container.Bind<ISaveLoadRegistry>().To<SaveLoadRegistry>()
                .AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>()
                .AsSingle();
        }

        void DiServiceBiding()
        {
            Container.Bind<IDiService>().To<DiService>().AsSingle();
        }
    }
}