using Scenes.GamePlay;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle();
        // Container.BindInterfacesAndSelfTo<GameStateService>()
        //     .AsSingle();
        // Container.BindInterfacesAndSelfTo<ScoreService>()
        //     .AsSingle();

        // Container.Bind<GamePlayButtonsController>()
        //     .FromComponentInHierarchy()
        //     .AsSingle();
    }
}