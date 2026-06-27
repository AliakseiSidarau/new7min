using System.Collections.Generic;
using Scenes.GamePlay;
using Scenes.Inventory;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    public List<ItemConfig> ItemConfigs;
    public GameObject ItemPrefab;
    public InventoryWindow InventoryWindow;
    
    public override void InstallBindings()
    {
        Container.Bind<Inventory>()
            .AsSingle()
            .WithArguments(5, 5);

        Container.Bind<IItemService>()
            .To<ItemService>()
            .AsSingle()
            .WithArguments(ItemConfigs);

        Container.Bind<ItemFactory>()
            .AsSingle()
            .WithArguments(ItemConfigs, ItemPrefab);

        Container.Bind<InventoryWindow>()
            .FromInstance(InventoryWindow)
            .AsSingle();
        
        Container.Bind<IPlayerService>()
            .To<PlayerService>()
            .AsSingle();
        
        Container.Bind<TurnManager>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}