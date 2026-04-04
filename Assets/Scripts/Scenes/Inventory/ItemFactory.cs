using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Scenes.Inventory;

public class ItemFactory
{
    private readonly DiContainer _container;
    private readonly List<ItemConfig> _configs;
    private readonly GameObject _prefab;

    public ItemFactory(DiContainer container, List<ItemConfig> configs, GameObject prefab)
    {
        _container = container;
        _configs = configs;
        _prefab = prefab;
    }

    public void CreateRandom(Vector3 pos)
    {
        var config = _configs[Random.Range(0, _configs.Count)];

        var go = _container.InstantiatePrefab(_prefab, pos, Quaternion.identity, null);
        go.GetComponent<ItemWorld>().Init(config);
    }
}