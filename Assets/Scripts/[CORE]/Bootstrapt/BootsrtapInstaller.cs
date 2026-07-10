using Scenes;
using UnityEngine;
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