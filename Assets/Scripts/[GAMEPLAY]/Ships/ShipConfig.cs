using Scenes.Ships;
using UnityEngine;

namespace Scenes.GamePlay
{
    [CreateAssetMenu(menuName = "Game/Ship Config")]
    public class ShipConfig : ScriptableObject
    {
        public Sprite icon;
        public ShipType type;
        public string displayName;
        public ShipStats stats;
        public string description;
    }
}