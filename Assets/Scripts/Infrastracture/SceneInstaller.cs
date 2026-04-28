using Scenes.GamePlay;
using Scenes.GamePlay.Upgrade;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class SceneInstaller: MonoInstaller
    {
        [SerializeField] private PlayerFacade _playerFacade;
        [SerializeField] private UpgradeView upgradeView;
        [SerializeField] private GameStats gameStats;

        public override void InstallBindings()
        {
            Container.Bind<PlayerFacade>().FromInstance(_playerFacade).AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
            Container.Bind<StatsService>().AsSingle();
            Container.Bind<UpgradeService>().AsSingle();
            Container.Bind<ProgressService>().AsSingle();
            Container.Bind<GameStats>()
                .FromInstance(gameStats)
                .AsSingle();
            Container.Bind<UpgradeView>()
                .FromInstance(upgradeView) 
                .AsSingle();
            Container.Bind<ShipModel>().AsSingle().NonLazy();
            Container.Bind<DiamondSpawner>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<EnergySystem>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.Bind<RadiusRenderer>().FromComponentInHierarchy().AsSingle();
            
            Debug.Log("SceneInstaller Install");
        }
    }
}