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
   
      private AudioService _audioService;
   
      void OnEnable()
      {
         _audioService = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioService>();
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
         _audioService.PlayClick();
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
         _audioService.PlayClick();
         SceneManager.LoadScene("1.Menu");
      }

      void LoseGame()
      {
         _audioService.PlayClick();
         SceneManager.LoadScene("3.GameOver");
      }

      void PlusScore()
      {
         _audioService.PlayClick();
         Counter.AddScore();
      }
   }
}
