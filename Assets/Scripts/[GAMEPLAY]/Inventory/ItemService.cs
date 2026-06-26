using System.Collections.Generic;
using Scenes.Inventory;

public class ItemService : IItemService
{
    private readonly Inventory _inventory;
    private readonly Dictionary<string, ItemConfig> _configs;

    public ItemService(Inventory inventory, List<ItemConfig> configs)
    {
        _inventory = inventory;

        _configs = new Dictionary<string, ItemConfig>();
        foreach (var config in configs)
            _configs[config.Id] = config;
    }

    public void AddItem(string id)
    {
        if (_configs.TryGetValue(id, out var config))
        {
            _inventory.TryAddItem(config);
        }
    }
}