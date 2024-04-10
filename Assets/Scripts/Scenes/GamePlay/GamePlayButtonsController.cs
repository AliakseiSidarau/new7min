using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayButtonsController : MonoBehaviour
{
   [SerializeField] private Button _pauseButton;
   [SerializeField] private Button _exitButton;
   [SerializeField] private TMP_Text _pauseText;
   
   private SoundEffectsPlayer _soundEffectsPlayer;
   
   void Start()
   {
      _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
      _pauseButton.onClick.AddListener(OpenPauseMenu);
      _exitButton.onClick.AddListener(ExitFromGamePlay);

   }

   void OpenPauseMenu()
   {
      if (Time.timeScale == 0f)
      {
         Time.timeScale = 1f;
         _pauseText.enabled = false;
      }
      else
      {
         Time.timeScale = 0f;
         _pauseText.enabled = true;
      }
      _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
   }

   void ExitFromGamePlay()
   {
      _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
      SceneManager.LoadScene("MainMenu");
   }
}
