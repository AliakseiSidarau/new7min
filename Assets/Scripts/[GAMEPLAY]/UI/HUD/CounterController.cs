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
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private EnergySystem _energySystem;
        [SerializeField] private PlayerFacade _playerFacade;
        
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
            Counter.BestScore = _progressService.Progress.WorldData.BestScore;
            Counter.OnBestScoreChanged += SaveBestScore;
        }

        private void OnDisable()
        {
            Counter.OnBestScoreChanged -= SaveBestScore;
        }

        void Update()
        {
            _energyText.text = $"{Mathf.RoundToInt(_energySystem.CurrentEnergyValue())} / {_energySystem.maxEnergy}";
            _healthText.text = $"{_playerFacade.CurrentHP} / {_playerFacade.MaxHP}";
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
