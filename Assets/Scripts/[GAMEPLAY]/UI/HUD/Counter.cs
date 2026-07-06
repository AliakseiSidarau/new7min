using System;

namespace Scenes.GamePlay

{
    public static class Counter

    {

        public static int Score { get; set; }
        public static int BestScore { get; set; }
        public static event Action OnBestScoreChanged;
        public static void AddScore()
        {
            Score++;
            if (Score > BestScore)
            {
                BestScore = Score;
                OnBestScoreChanged?.Invoke();
            }
        }

        public static int ReturnScore()
        {
            return Score;
        }

        public static int ReturnBestScore()
        {
            return BestScore;
        }

        public static void ResetScore()
        {
            Score = 0;
        }

        public static void SetBestScore(int bestScore)
        {
            BestScore = bestScore;
        }

    }

}