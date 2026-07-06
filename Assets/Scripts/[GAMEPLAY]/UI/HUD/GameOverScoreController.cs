using Infrastracture.SaveLoad.Progress;
using Scenes.GamePlay;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scenes.GameOver
{
    public class GameOverScoreController: MonoBehaviour
    {
        [SerializeField] private TMP_Text _yourScore;
        [SerializeField] private TMP_Text _bestScore;
        private IProgressService _progressService;
        
        [Inject]
        public void Construct( IProgressService progressService)
        {
            Debug.Log("Construct called");
            _progressService = progressService;
        }
        
        
        private void Update()
        {
            _yourScore.text = Counter.Score.ToString();
            _bestScore.text = _progressService.Progress.WorldData.BestScore.ToString();
        }
    }
}