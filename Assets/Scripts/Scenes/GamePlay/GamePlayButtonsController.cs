using System;
using DefaultNamespace;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.GamePlay
{
   public class GamePlayButtonsController : MonoBehaviour
   {
      [SerializeField] private Button _pauseButton;
      [SerializeField] private Button _exitButton;
      [SerializeField] private Button _loseGameButton;
      [SerializeField] private Button _plusScoreButton;
   
      [SerializeField] private TMP_Text _pauseText;
   
      private SoundEffectsPlayer _soundEffectsPlayer;
   
      void OnEnable()
      {
         _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
         _pauseButton.onClick.AddListener(OpenPauseMenu);
         _exitButton.onClick.AddListener(ExitFromGamePlay);
         _loseGameButton.onClick.AddListener(LoseGame);
         _plusScoreButton.onClick.AddListener(PlusScore);
         Counter.Score = 0;
         OnSubscribe();
      }

      private void OnDisable()
      {
         OnUnsubscribe();
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

      void OnSubscribe()
      {
         Player.OnPlayerWasDied += LoseGame;
      }

      void OnUnsubscribe()
      {
         Player.OnPlayerWasDied -= LoseGame;
      }

      void ExitFromGamePlay()
      {
         _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.click);
         SceneManager.LoadScene("MainMenu");
      }

      void LoseGame()
      {
         _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.claim);
         SceneManager.LoadScene("GameOver");
      }

      void PlusScore()
      {
         _soundEffectsPlayer.PlayClick(_soundEffectsPlayer.claim);
         Counter.AddScore();
      }
   }
}
