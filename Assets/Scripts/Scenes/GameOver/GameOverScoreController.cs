using Scenes.GamePlay;
using TMPro;
using UnityEngine;

namespace Scenes.GameOver
{
    public class GameOverScoreController: MonoBehaviour
    {
        [SerializeField] private TMP_Text _yourScore;
        [SerializeField] private TMP_Text _bestScore;
        
        
        void Update()
        {
            _yourScore.text = Counter.Score.ToString();
            _bestScore.text = CounterController.GetBestForLoseScreen().ToString();
        }
    }
}