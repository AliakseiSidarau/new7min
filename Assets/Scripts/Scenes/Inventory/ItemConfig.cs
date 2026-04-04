using UnityEngine;

namespace Scenes.Inventory
{
    [CreateAssetMenu(menuName = "Game/Item Config")]
    public class ItemConfig: ScriptableObject
    {
        public string Id;
        public string Name;
        public Sprite Icon;
        public string Description;
        public float Weight;
    }
}