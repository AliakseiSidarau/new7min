using Unity.VisualScripting;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil.Cil;
using IInitializable = Zenject.IInitializable;

namespace Sound
{
    public sealed class AudioService : MonoBehaviour,IAudioService, IInitializable
    {
        private AudioSource _musicSource;
        private AudioSource _sfxSource;
        
        private AudioClip _click;
        private AudioClip _background;
        private AudioClip _claim;
        private AudioClip _boom;

        public void Initialize()
        {
            _click = Resources.Load<AudioClip>("Music/click");
            _background = Resources.Load<AudioClip>("Music/music");
            _claim = Resources.Load<AudioClip>("Music/claim");
            _boom = Resources.Load<AudioClip>("Music/boom");

            MakeSfxSource();
            MakeMusicSource();
        }

        private void MakeMusicSource()
        {
            var musicSource = new GameObject("AudioSource_Music");
            musicSource.transform.SetParent(transform,false);
            _musicSource = musicSource.AddComponent<AudioSource>();
        }

        private void MakeSfxSource()
        {
            var sfxSource = new GameObject("AudioSource_SFX");
            sfxSource.transform.SetParent(transform, false);
            _sfxSource = sfxSource.AddComponent<AudioSource>();
        }
        
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
            if (_sfxSource == null)
            {
                Debug.Log("SFX Source null!");
                return;
            }
            _sfxSource.PlayOneShot(_click);
        }

        public void PlayClaim()
        {
            if (_sfxSource == null)
            {
                Debug.Log("SFX Source null!");
                return;
            }
            _sfxSource.PlayOneShot(_claim);
        }

        public void PlayBoom()
        {
            if (_sfxSource == null)
            {
                Debug.Log("SFX Source null!");
                return;
            }
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