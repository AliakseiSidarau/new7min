namespace Scenes.GamePlay
{
    public class Counter
    {
        private int _score;
        
        public static int Score { get; set; }

        public static void AddScore()
        {
            Score++;
        }

        public static int ReturnScore()
        {
            return Score;
        }
    }
}