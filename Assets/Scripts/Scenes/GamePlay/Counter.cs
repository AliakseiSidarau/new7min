namespace Scenes.GamePlay
{
    public class Counter
    {
        private int _score;
        
        public static int Score { get; set; }
        
        public static int ReturnScore()
        {
            return Score;
        }
    }
}