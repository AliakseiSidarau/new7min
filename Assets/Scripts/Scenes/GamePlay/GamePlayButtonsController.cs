using System;
using DefaultNamespace;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Scenes.GamePlay
{
   public class GamePlayButtonsController : MonoBehaviour
   {
      [SerializeField] private Button _pauseButton;
      [SerializeField] private Button _exitButton;
      [SerializeField] private Button _loseGameButton;
      [SerializeField] private Button _plusScoreButton;
   
      [SerializeField] private TMP_Text _pauseText;
   
      private IAudioService _audioService;

      [Inject]
      public void Construct(IAudioService audioService)
      {
         _audioService = audioService;
      }
      
      void OnEnable()
      {
         _pauseButton.onClick.AddListener(OpenPauseMenu);
         _exitButton.onClick.AddListener(ExitFromGamePlay);
         _loseGameButton.onClick.AddListener(LoseGame);
         _plusScoreButton.onClick.AddListener(PlusScore);
         Counter.Score = 0;
         OnSubscribe();
      }

      private void OnDisable()
      {
         _pauseButton.onClick.RemoveAllListeners();
         _exitButton.onClick.RemoveAllListeners();
         _loseGameButton.onClick.RemoveAllListeners();
         _plusScoreButton.onClick.RemoveAllListeners();
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
