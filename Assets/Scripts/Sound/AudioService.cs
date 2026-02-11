using UnityEngine;

namespace Sound
{
    public sealed class AudioService : MonoBehaviour, IAudioService
    {
        [Header("------------------ Audio Source ------------------")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("------------------ Audio Clip ------------------")]
        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _background;
        [SerializeField] private AudioClip _claim;
        [SerializeField] private AudioClip _boom;

        public void PlayBackgroundMusic()
        {
            _musicSource.clip = _background;
            _musicSource.Play();
        }
        
        public bool SoundStateCheaker()
        {
            bool isSoundOn;
            isSoundOn = _sfxSource.mute != true;
            return isSoundOn;
        }

        public bool MusicStateCheaker()
        {
            bool isMusicOn;
            isMusicOn = _musicSource.mute != true;
            return isMusicOn;
        }

        public void PlayClick()
        {
           _sfxSource.PlayOneShot(_click);
        }

        public void PlayClaim()
        {
            _sfxSource.PlayOneShot(_claim);
        }

        public void PlayBoom()
        {
            _sfxSource.PlayOneShot(_boom);
        }
        public void SwitchSound()
        {
            _sfxSource.mute = !_sfxSource.mute;
        }

        public void SwitchMusic()
        {
            _musicSource.mute = !_musicSource.mute;
        }
    }
}