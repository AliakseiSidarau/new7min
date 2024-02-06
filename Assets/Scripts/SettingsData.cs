namespace DefaultNamespace
{
    [System.Serializable]
    public class SettingsData
    {
        public bool sound;
        public bool music;
        public bool vibration;

        public SettingsData(SettingsController settingsController)
        {
            sound = settingsController.Sound;
            music = settingsController.Music;
            vibration = settingsController.Vibration;
        }
    }
}