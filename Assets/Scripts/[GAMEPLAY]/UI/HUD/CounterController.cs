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
        [SerializeField] private TMP_Text _energyText;
        [SerializeField] private EnergySystem _energySystem;
        
        private ISaveLoadService _saveLoadService;
        private IProgressService _progressService;

        private float _MaxEnergy;
        private float _CurrentEnergy;
        
        [Inject]
        public void Construct(ISaveLoadService saveLoadService, IProgressService progressService)
        {
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        void OnEnable()
        {
            _CurrentEnergy = _energySystem.currentEnergy;
            _MaxEnergy = _energySystem.maxEnergy;
            Counter.BestScore = _progressService.Progress.WorldData.BestScore;
            Counter.OnBestScoreChanged += SaveBestScore;
        }

        private void OnDisable()
        {
            Counter.OnBestScoreChanged -= SaveBestScore;
        }

        void Update()
        {
            _energyText.text = $"{Mathf.RoundToInt(_energySystem.CurrentEnergyValue())} / {_MaxEnergy}";
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
