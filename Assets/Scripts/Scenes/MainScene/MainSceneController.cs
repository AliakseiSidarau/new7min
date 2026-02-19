using DefaultNamespace;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace Scenes.MainScene
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitButton;
    
        [SerializeField] private TMP_Text _versionLabel;
    
        [SerializeField] private GameObject _manuWindowPrefab;
        [SerializeField] private GameObject _settingsWindowPrefab;
    
        [SerializeField] private string _versionText = "v 0.0.1";
        private IAudioService _audioService;
        private ISceneManagerService _sceneManagerService;

        [Inject]
        public void Construct(ISceneManagerService sceneManagerService, IAudioService audioService)
        {
            _audioService = audioService;
            _sceneManagerService = sceneManagerService;
        }
        

        void Start()
        {
            _settingsButton.onClick.AddListener(OpenSettings);
            _startGameButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitApplication);
            _versionLabel.text = _versionText;
        }

        void ExitApplication()
        {
            _audioService.PlayClick();
            Debug.Log("Exit button clicked!");
            Application.Quit();
        }
        void StartGame()
        {
            _audioService.PlayClick();
            Debug.Log("Start Game button clicked!");
            _sceneManagerService.LoadGameScene();
        }

        void OpenSettings()
        {
            _audioService.PlayClick();
            Debug.Log("Settings button clicked!");
            _manuWindowPrefab.SetActive(false);
            _settingsWindowPrefab.SetActive(true);
        }
    }
}
