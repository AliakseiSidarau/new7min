using TMPro;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class CounterController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        [SerializeField] private TMP_Text _bestScoreText;
        [SerializeField] private int _needScoresForUpgrade;
        private int _currentScore;
        private int _bestScore;
        private bool _upgradeTriggered;
        
        private const string BestScoreKey = "bestScoreKey";

        static int BestScore { get; set; }
  
        void Start()
        {
            if (PlayerPrefs.HasKey(BestScoreKey))
            {
                BestScore = PlayerPrefs.GetInt(BestScoreKey);
            }
            else
            {
                BestScore = 0;
            }

            _bestScoreText.text = PlayerPrefs.GetInt(BestScoreKey).ToString();
            _counterText.text = "0";
        }

        void Update()
        {
            _counterText.text = Counter.Score.ToString();
            _currentScore = Counter.ReturnScore();
            if (!_upgradeTriggered && _currentScore >= _needScoresForUpgrade)
            {
                _upgradeTriggered = true;
                
                Debug.Log("Trigger Upgrade Window");
                
            }
            BestScore = GetBest(_currentScore);
            _bestScoreText.text = BestScore.ToString();
        }

        private int GetBest( int curScore)
        {
            if (curScore >= BestScore)
            {
                BestScore = curScore;
                PlayerPrefs.SetInt(BestScoreKey, curScore);
                return curScore;
            }
            else
            {
                return BestScore;
            } 
        }

        public static int GetBestForLoseScreen()
        {
            return BestScore;
        }
    }
}
