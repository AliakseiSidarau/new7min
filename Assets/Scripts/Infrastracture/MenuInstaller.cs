using Scenes;
using Sound;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Container.Bind<IAudioService>().FromResolve().AsCached();
        // Container.Bind<ISceneManagerService>().FromResolve().AsCached();
    }
}