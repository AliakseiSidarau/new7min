using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Button _closeSettingsButton;
    [SerializeField] private Button _soundSwitchButton;
    [SerializeField] private Button _musicSwitchButton;
    [SerializeField] private Button _vibrationSwitchButton;

    [SerializeField] private GameObject _manuWindowPrefab;
    [SerializeField] private GameObject _settingsWindowPrefab;
    void Start()
    {
        _closeSettingsButton.onClick.AddListener(CloseSettingsWindow);
        _soundSwitchButton.onClick.AddListener(SwitchSound);
        _musicSwitchButton.onClick.AddListener(SwitchMusic);
        _vibrationSwitchButton.onClick.AddListener(SwitchVibration);
    }

    void CloseSettingsWindow()
    {
        Debug.Log("CloseSettings button clicked!");
        _settingsWindowPrefab.SetActive(false);
        _manuWindowPrefab.SetActive(true);
    }

    void SwitchSound()
    {
        Debug.Log("Sound button clicked!");
    }
    
    void SwitchMusic()
    {
        Debug.Log("Music button clicked!");
    }
    
    void SwitchVibration()
    {
        Debug.Log("Vibration button clicked!");
    }
}
