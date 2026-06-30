using System;

namespace Infrastracture.SaveLoad.Data
{
    [Serializable]
    public class PlayerData
    {
        public int CurrentHealth;
        public int CurrentShield;
        public int CurrentEnergy;
        public int CurrentScore;
        public int MaxHealth;
        public int MaxShield;
        public int MaxEnergy;
    }
}