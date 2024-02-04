using UnityEngine;

namespace DefaultNamespace
{
    public class SoundEffectsPlayer : MonoBehaviour
    {
        [Header("------------------ Audio Source ------------------")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [Header("------------------ Audio Clip ------------------")]
        public AudioClip click;
        
        public void PlayClick(AudioClip click)
        {
           _sfxSource.PlayOneShot(click);
        }
    }
}