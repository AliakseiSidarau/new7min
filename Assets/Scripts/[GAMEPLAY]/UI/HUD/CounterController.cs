using System;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Progress;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class CounterController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        [SerializeField] private TMP_Text _bestScoreText;
        
        private ISaveLoadService _saveLoadService;
        private IProgressService _progressService;
        
        [Inject]
        public void Construct(ISaveLoadService saveLoadService, IProgressService progressService)
        {
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        void OnEnable()
        {
            Counter.OnBestScoreChanged += SaveBestScore;
        }

        private void OnDisable()
        {
            Counter.OnBestScoreChanged -= SaveBestScore;
        }

        void Update()
        {
            _counterText.text = $"Score: {Counter.ReturnScore()}";
            _bestScoreText.text = $"Best Score: {Counter.ReturnBestScore()}";
        }

        void SaveBestScore()
        {
            _progressService.Progress.WorldData.BestScore = Counter.ReturnBestScore();
            _saveLoadService.Save();
        }
    }
}
