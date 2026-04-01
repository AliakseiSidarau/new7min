using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "CheastConfig", menuName = "Config/CheastConfigData")]
    public class CheastConfigData: ScriptableObject
    {
        public string Id;
        public string Name;
        public int Reward;
        public long DelaySeconds;
        public Sprite Icon;
    }
}