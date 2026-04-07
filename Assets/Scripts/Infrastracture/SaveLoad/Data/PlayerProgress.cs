using System;

namespace Infrastracture.SaveLoad.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData = new WorldData();
        public PlayerData PlayerData = new PlayerData();
        public EnemyData EnemyData = new EnemyData();
        public SettingsData SettingsData =  new SettingsData();
    }
}