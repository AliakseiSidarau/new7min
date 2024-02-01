using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _exitButton;
    
    [SerializeField] private Text _versionLabel;
    
    [SerializeField] private GameObject _manuWindowPrefab;
    [SerializeField] private GameObject _settingsWindowPrefab;

    void Start()
    {
        _settingsButton.onClick.AddListener(OpenSettings);
        _startGameButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitApplication);
    }

    void ExitApplication()
    {
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }
    void StartGame()
    {
        Debug.Log("Start Game button clicked!");
        SceneManager.LoadScene("Game");
    }

    void OpenSettings()
    {
        Debug.Log("Settings button clicked!");
        _manuWindowPrefab.SetActive(false);
        _settingsWindowPrefab.SetActive(true);
    }
}
