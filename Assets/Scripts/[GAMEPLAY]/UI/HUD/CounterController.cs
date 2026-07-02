using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Progress;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class CounterController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        [SerializeField] private TMP_Text _bestScoreText;
        private int _currentScore;
        private int _bestScore;

        
        
        private const string BestScoreKey = "bestScoreKey";

        static int BestScore { get; set; }
        
        private ISaveLoadService _saveLoadService;
        private IProgressService _progressService;
        
        [Inject]
        public void Construct(ISaveLoadService saveLoadService, IProgressService progressService)
        {
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        /*void Start()
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
        }*/

        void Update()
        {
            _currentScore = Counter.ReturnScore();
            _counterText.text = "Score: " + _currentScore;
            
            BestScore = GetBest(_currentScore);
            _bestScoreText.text = "Best Score: " + BestScore;
        }

        private int GetBest( int curScore)
        {
            if (curScore < BestScore) return BestScore;
            BestScore = curScore;
            PlayerPrefs.SetInt(BestScoreKey, curScore);
            return curScore;

        }

        public static int GetBestForLoseScreen()
        {
            return BestScore;
        }
    }
}
