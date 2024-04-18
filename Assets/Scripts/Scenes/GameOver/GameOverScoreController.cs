using Scenes.GamePlay;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameOverScoreController: MonoBehaviour
    {
        [SerializeField] private TMP_Text _yourScore;
        
        void Update()
        {
            _yourScore.text = Counter.Score.ToString();
        }
    }
}