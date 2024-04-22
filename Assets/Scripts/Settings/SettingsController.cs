using DefaultNamespace;
using Unity.VisualScripting;
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

    public bool Sound { set; get; }
    public bool Music { set; get; }
    public bool Vibration { set; get; }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(this);
        Debug.LogWarning($"SAVED!!! Sound - {Sound}, music - {Music}, vibration - {Vibration}");
    }

    public void LoadSettings()
    {
        SettingsData data = SaveSystem.LoadSettings();
        Sound = data.sound;
        Music = data.music;
        Vibration = data.vibration;
        Debug.LogWarning($"LOADED!!! Sound - {Sound}, music - {Music}, vibration - {Vibration}");

    }

    void Awake()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
        LoadSettings();
        _soundEffectsPlayer.MusicCheaker(Music);
        _soundEffectsPlayer.SoundCheaker(Sound);
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
        SaveSettings();
    }

    void SwitchSound()
    {
        _soundEffectsPlayer.SwitchSound();
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Sound = !Sound;
        Debug.Log($"Sound button clicked! - {Sound}");
    }
    
    void SwitchMusic()
    {
        _soundEffectsPlayer.SwitchMusic();
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Music = !Music;
        Debug.Log($"Music button clicked! - {Music}");
    }
    
    void SwitchVibration()
    {
        _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
        Vibration = !Vibration;
        Debug.Log($"Vibration button clicked! - {Vibration}");
    }
}
