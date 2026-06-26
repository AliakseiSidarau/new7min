namespace Sound
{
    public interface IAudioService
    {
        public void PlayBackgroundMusic();
        public bool SoundStateCheaker();
        public bool MusicStateCheaker();
        public void PlayClick();
        public void PlayClaim();
        public void PlayBoom();
        public void SwitchSound();
        public void SwitchMusic();
    }
}