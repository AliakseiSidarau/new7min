using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Button _closeSettingsButton;
    [SerializeField] private Button _soundSwitchButton;
    [SerializeField] private Button _musicSwitchButton;
    [SerializeField] private Button _vibrationSwitchButton;

    [SerializeField] private GameObject _manuWindowPrefab;
    [SerializeField] private GameObject _settingsWindowPrefab;

    private SoundEffectsPlayer _soundEffectsPlayer;
    
    private bool _sound;
    private bool _music;
    private bool _vibration;

    public bool Sound => _sound;
    public bool Music => _music;
    public bool Vibration => _vibration;
   

    void Awake()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
    }

    void Start()
    {
        _closeSettingsButton.onClick.AddListener(CloseSettingsWindow);
        _soundSwitchButton.onClick.AddListener(SwitchSound);
        _musicSwitchButton.onClick.AddListener(SwitchMusic);
        _vibrationSwitchButton.onClick.AddListener(SwitchVibration);
    }

    void CloseSettingsWindow()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("CloseSettings button clicked!");
        _settingsWindowPrefab.SetActive(false);
        _manuWindowPrefab.SetActive(true);
    }

    void SwitchSound()
    {
        _soundEffectsPlayer.SwitchSound();
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Sound button clicked!");
    }
    
    void SwitchMusic()
    {
        _soundEffectsPlayer.SwitchMusic();
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Music button clicked!");
    }
    
    void SwitchVibration()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Debug.Log("Vibration button clicked!");
    }
}
