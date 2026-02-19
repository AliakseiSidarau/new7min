using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

namespace Scenes.GameOver
{
    public class GameOverSceneController : MonoBehaviour
    {
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _exitGameButton;

        void OnEnable()
        {
            _restartGameButton.onClick.AddListener(RestartGame);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartGameButton.onClick.RemoveAllListeners();
            _exitGameButton.onClick.RemoveAllListeners();
        }

        void RestartGame()
        {
            SceneManager.LoadScene("2.Game");
        }

        void ExitGame()
        {
            Application.Quit();
        }
    }
}