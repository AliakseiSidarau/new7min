using DefaultNamespace;
using Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private Button _closeSettingsButton;
        [SerializeField] private Button _soundSwitchButton;
        [SerializeField] private Button _musicSwitchButton;
        [SerializeField] private Button _vibrationSwitchButton;

        [SerializeField] private GameObject _manuWindowPrefab;
        [SerializeField] private GameObject _settingsWindowPrefab;
        [SerializeField] private SaveService _saveService;

        private AudioService _audioService;
    
        private bool _sound;
        private bool _music;
        private bool _vibration;

        public bool Sound { set; get; }
        public bool Music { set; get; }
        public bool Vibration { set; get; }

        public void SaveSettings()
        {
            _saveService.SaveSettingsData(this);
            Debug.LogWarning($"SAVED!!! Sound - {Sound}, music - {Music}, vibration - {Vibration}");
        }

        public void LoadSettings()
        {
            _saveService.LoadSettingsData();
            Sound = _sound;
            Music = _music;
            Vibration = _vibration;
            Debug.LogWarning($"LOADED!!! Sound - {Sound}, music - {Music}, vibration - {Vibration}");

        }

        void Awake()
        {
            _audioService = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioService>();
            LoadSettings();
            
            // _audioService.MusicCheaker(Music);
            // _audioService.SoundCheaker(Sound);
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
            _audioService.PlayClick();
            Debug.Log("CloseSettings button clicked!");
            _settingsWindowPrefab.SetActive(false);
            _manuWindowPrefab.SetActive(true);
            SaveSettings();
        }

        void SwitchSound()
        {
            _audioService.SwitchSound();
            _audioService.PlayClick();
            Sound = !Sound;
            Debug.Log($"Sound button clicked! - {Sound}");
        }
    
        void SwitchMusic()
        {
            _audioService.SwitchMusic();
            _audioService.PlayClick();
            Music = !Music;
            Debug.Log($"Music button clicked! - {Music}");
        }
    
        void SwitchVibration()
        {
            _audioService.PlayClick();
            Vibration = !Vibration;
            Debug.Log($"Vibration button clicked! - {Vibration}");
        }
    }
}
