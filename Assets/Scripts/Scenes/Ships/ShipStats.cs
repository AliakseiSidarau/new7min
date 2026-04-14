using System;

namespace Scenes.GamePlay
{
    [Serializable]
    public class ShipStats
    {
        public float maxEnergy = 100f;
        public float moveCostMultiplier = 1f;
        public float speed = 5f;
        public float energyFromDiamond = 30f;
        public float damageResistance = 1f;
    }
}