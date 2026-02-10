using UnityEngine;

namespace Sound
{
    public class SoundEffectsPlayer : MonoBehaviour
    {
        [Header("------------------ Audio Source ------------------")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("------------------ Audio Clip ------------------")]
        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _background;
        [SerializeField] private AudioClip _claim;
        [SerializeField] private AudioClip _boom;

        private void Start()
        {
            _musicSource.clip = _background;
            _musicSource.Play();
        }
        
        public void SoundCheaker(bool soundState)
        {
            Debug.Log($"Sound state -> {soundState}");
            if (soundState == false)
            {
                _sfxSource.mute = true;
            }
            _sfxSource.mute = false;
            Debug.Log($"I've check! SFX - {_sfxSource.mute}");
        }

        public void MusicCheaker(bool musicState)
        {
            Debug.Log($"Music state -> {musicState}");
            if (musicState == false)
            {
                _musicSource.mute = true;
            }
            _musicSource.mute = false;
            Debug.Log($"I've check! Music - {_musicSource.mute}");
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