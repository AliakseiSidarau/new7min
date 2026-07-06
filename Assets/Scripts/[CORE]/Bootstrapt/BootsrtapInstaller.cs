using System;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Progress;
using Scenes;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastracture
{
    public class BootstrapInstaller: MonoInstaller
    {
       
        public override void InstallBindings()
        {
            BindSceneManagerService();
            BindBootstrapSystem();
        }

        void BindBootstrapSystem()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInitializeSystem>()
                .AsSingle();
            
            Debug.Log("Bootstrap biding was finished!");
        }

        void BindSceneManagerService()
        {
            Container.BindInterfacesAndSelfTo<SceneManagerService>()
                .AsSingle()
                .NonLazy();
        }
    }
}