using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneManagerService: ISceneManagerService
    {
        private string _menuScaneLabel = "1.Menu";
        private string _gameScaneLabel = "2.Game";
        private string _overScaneLabel = "3.GameOver";

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(_menuScaneLabel);
            Debug.Log("Manu scene was loaded!");
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(_gameScaneLabel);
            Debug.Log("Game scene was loaded!");
        }

        public void LoadEndGameScene()
        {
            SceneManager.LoadScene(_overScaneLabel);
            Debug.Log("GameOver scene was loaded!");
        }
    }
}