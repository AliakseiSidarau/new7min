using System;
using System.Reflection.Emit;
using DefaultNamespace;
using Sound;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
        
        public bool Sound { get; private set; }
        public bool Music { get; private set; }
        public bool Vibration { get; private set; }

        public event Action OnCloseClicked;
        public event Action OnSoundClicked;
        public event Action OnMusicCliced;
        public event Action OnVibroClicked;
        
        private ISaveService _saveService;

        [Inject]
        void Construct(ISaveService saveService)
        {
            _saveService = saveService;
        }

        public void SaveSettings()
        {
            _saveService.SaveSettingsData(this);
        }

        public void LoadSettings()
        {
            _saveService.LoadSettingsData();
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
            Debug.Log("CloseSettings button clicked!");
            OnCloseClicked?.Invoke();
            _settingsWindowPrefab.SetActive(false);
            _manuWindowPrefab.SetActive(true);
            SaveSettings();
        }

        void SwitchSound()
        {
            Sound = !Sound;
            OnSoundClicked?.Invoke();
        }
    
        void SwitchMusic()
        {
            Music = !Music;
            OnMusicCliced?.Invoke();
        }
    
        void SwitchVibration()
        {
            Vibration = !Vibration;
            OnVibroClicked?.Invoke();
        }
    }
}
