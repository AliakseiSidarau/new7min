using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SoundEffectsPlayer : MonoBehaviour
    {
        [Header("------------------ Audio Source ------------------")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private AudioSource _claim;

        [Header("------------------ Audio Clip ------------------")]
        public AudioClip click;
        public AudioClip background;
        public AudioClip claim;

        private void Start()
        {
            _musicSource.clip = background;
            _musicSource.Play();
        }

        public void PlayClick(AudioClip click)
        {
           _sfxSource.PlayOneShot(click);
        }

        public void PlayClaim(AudioClip claim)
        {
            _sfxSource.PlayOneShot(claim);
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