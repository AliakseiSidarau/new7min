using Data;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class BootsrtapInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInitializeSystem>()
                .AsSingle();
            Debug.Log("Bootstrap biding was finished!");

            Container.BindInterfacesAndSelfTo<SaveService>()
                .AsSingle()
                .NonLazy();
            Debug.Log("SaveService biding was finished!");
        }
    }
}