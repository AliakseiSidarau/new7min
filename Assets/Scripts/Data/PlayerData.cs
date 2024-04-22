namespace DefaultNamespace
{
    [System.Serializable]
    
    public class PlayerData
    {
        public int bestScore;

        public PlayerData(PlayerDataController pdc)
        {
            bestScore = pdc.BestScore;
        }
    }
    
    
}