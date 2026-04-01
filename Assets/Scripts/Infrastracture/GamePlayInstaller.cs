using System.Collections.Generic;
using Config;
using Core;
using Scenes.GamePlay;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    [SerializeField] private List<CheastConfigData> _cheastConfigs;
    public override void InstallBindings()
    {
        Container.Bind<ITimeService>()
            .To<DeviceTimeService>()
            .AsSingle();

        Container.Bind<ChestService>()
            .AsSingle()
            .WithArguments(_cheastConfigs);
    // Container.BindInterfacesAndSelfTo<GameStateService>()
    //     .AsSingle();
    // Container.BindInterfacesAndSelfTo<ScoreService>()
    //     .AsSingle();

    // Container.Bind<GamePlayButtonsController>()
    //     .FromComponentInHierarchy()
    //     .AsSingle();
    }
}