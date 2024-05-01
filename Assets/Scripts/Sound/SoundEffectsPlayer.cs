using UnityEngine;

namespace Sound
{
    public class SoundEffectsPlayer : MonoBehaviour
    {
        [Header("------------------ Audio Source ------------------")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("------------------ Audio Clip ------------------")]
        public AudioClip click;
        public AudioClip background;
        public AudioClip claim;
        public AudioClip boom;

        private void Start()
        {
            _musicSource.clip = background;
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

        public void PlayClick(AudioClip click)
        {
           _sfxSource.PlayOneShot(click);
        }

        public void PlayClaim(AudioClip claim)
        {
            _sfxSource.PlayOneShot(claim);
        }

        public void PlayBoom(AudioClip boom)
        {
            _sfxSource.PlayOneShot(boom);
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