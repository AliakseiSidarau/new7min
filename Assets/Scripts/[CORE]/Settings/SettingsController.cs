using System;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Data;
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
        [SerializeField] private Button _deleteMyProgressButton;

        [SerializeField] private GameObject _manuWindowPrefab;
        [SerializeField] private GameObject _settingsWindowPrefab;
        
        public bool Sound { get; private set; }
        public bool Music { get; private set; }
        public bool Vibration { get; private set; }

        public event Action OnCloseClicked;
        public event Action OnSoundClicked;
        public event Action OnMusicCliced;
        public event Action OnVibroClicked;
        
        [Inject] 
        private ISaveLoadService _saveLoadService;
        
        void OnEnable()
        {
            _closeSettingsButton.onClick.AddListener(CloseSettingsWindow);
            _soundSwitchButton.onClick.AddListener(SwitchSound);
            _musicSwitchButton.onClick.AddListener(SwitchMusic);
            _vibrationSwitchButton.onClick.AddListener(SwitchVibration);
            _deleteMyProgressButton.onClick.AddListener(Reset);
        }

        void OnDisable()
        {
            _closeSettingsButton.onClick.RemoveListener(CloseSettingsWindow);
            _soundSwitchButton.onClick.RemoveListener(SwitchSound);
            _musicSwitchButton.onClick.RemoveListener(SwitchMusic);
            _vibrationSwitchButton.onClick.RemoveListener(SwitchVibration);
            _deleteMyProgressButton.onClick.RemoveListener(Reset);
        }

        void CloseSettingsWindow()
        {
            Debug.Log("CloseSettings button clicked!");
            OnCloseClicked?.Invoke();
            _settingsWindowPrefab.SetActive(false);
            _manuWindowPrefab.SetActive(true);
        }

        void SwitchSound()
        {
            Sound = !Sound;
            OnSoundClicked?.Invoke();
            _saveLoadService.Save();
        }
    
        void SwitchMusic()
        {
            Music = !Music;
            OnMusicCliced?.Invoke();
            _saveLoadService.Save();
        }
    
        void SwitchVibration()
        {
            Vibration = !Vibration;
            OnVibroClicked?.Invoke();
            _saveLoadService.Save();
        }

        public void Save(PlayerProgress progress)
        {
            Debug.Log("Player Settings data saved!");
            progress.SettingsData.iSMusicOn = Music;
            progress.SettingsData.iSSoundOn = Sound;
            progress.SettingsData.isVibroOn = Vibration;
        }

        public void Load(PlayerProgress progress)
        {
            Music = progress.SettingsData.iSMusicOn;
            Sound = progress.SettingsData.iSSoundOn;
            Vibration = progress.SettingsData.isVibroOn;
            Debug.Log($"Loaded Progress: {JsonUtility.ToJson(progress)}");
        }

        public void Reset()
        {
            Debug.Log("Player data reset!");
            _saveLoadService.Reset();
        }
    }
}
