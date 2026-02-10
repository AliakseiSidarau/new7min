using DefaultNamespace;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private AudioService _audioService;
    
        // [SerializeField] private SettingsController _settingsController;

    
        void Awake()
        {
            _audioService = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioService>();
            //_settingsController = GetComponent<SettingsController>();
            // _settingsController.LoadSettings();
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
            SceneManager.LoadScene("2.Game");
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
