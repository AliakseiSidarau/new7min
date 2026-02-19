using System;
using Sound;
using Zenject;

namespace Settings
{
    public class SettingsSoundMediator: IInitializable, IDisposable
    {
        private readonly SettingsController _settings;
        private readonly IAudioService _audioService;

        public SettingsSoundMediator(SettingsController settings, IAudioService audioService)
        {
            _settings = settings;
            _audioService = audioService;
        }
        
        public void Initialize()
        {
            _settings.OnCloseClicked += HandleClose;
            _settings.OnSoundClicked += HandleSound;
            _settings.OnMusicCliced += HandleMusic;
            _settings.OnVibroClicked += HandleVibro;
        }

        public void Dispose()
        {
            _settings.OnCloseClicked -= HandleClose;
            _settings.OnSoundClicked -= HandleSound;
            _settings.OnMusicCliced -= HandleMusic;
            _settings.OnVibroClicked -= HandleVibro;
        }

        void HandleClose()
        {
            _audioService.PlayClick();
        }

        void HandleSound()
        {
            _audioService.PlayClick();
            _audioService.SwitchSound();
        }

        void HandleMusic()
        {
            _audioService.PlayClick();
            _audioService.SwitchMusic();
        }

        void HandleVibro()
        {
            _audioService.PlayClick();
        }
    }
}