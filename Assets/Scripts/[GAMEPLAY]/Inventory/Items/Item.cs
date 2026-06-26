using UnityEditor;

namespace Scenes.Inventory.Items
{
    public class Item
    {
        public ItemConfig Config { get; }

        public Item(ItemConfig config)
        {
            Config = config;
        }
    }
}