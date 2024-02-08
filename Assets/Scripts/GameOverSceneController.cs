using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class GameOverSceneController : MonoBehaviour
    {
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _exitGameButton;

        void Start()
        {
            _restartGameButton.onClick.AddListener(RestartGame);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }

        void ExitGame()
        {
            Application.Quit();
        }
    }
}