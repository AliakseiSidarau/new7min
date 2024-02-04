using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _exitButton;
    
    [SerializeField] private TMP_Text _versionLabel;
    
    [SerializeField] private GameObject _manuWindowPrefab;
    [SerializeField] private GameObject _settingsWindowPrefab;
    private SoundEffectsPlayer _soundEffectsPlayer;

    
    void Awake()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
    }

    void Start()
    {
        _settingsButton.onClick.AddListener(OpenSettings);
        _startGameButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitApplication);
        _versionLabel.text = "v 0.0.1";
    }

    void ExitApplication()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }
    void StartGame()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Start Game button clicked!");
        SceneManager.LoadScene("Game");
    }

    void OpenSettings()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Settings button clicked!");
        _manuWindowPrefab.SetActive(false);
        _settingsWindowPrefab.SetActive(true);
    }
}
