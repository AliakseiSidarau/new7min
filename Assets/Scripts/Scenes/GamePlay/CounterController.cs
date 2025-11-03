using System;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;

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

        private void OnEnable()
        {
            PlayerCollisionController.OnDiamondWasReceived += AddScore;
        }

        private void OnDisable()
        {
            PlayerCollisionController.OnDiamondWasReceived -= AddScore;
        }

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

        private void AddScore()
        {
            Counter.Score++;
        }
    }
}
