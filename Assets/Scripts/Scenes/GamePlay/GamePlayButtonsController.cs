using System;
using Scenes.GamePlay.Upgrade;
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
      [SerializeField] private Button _upgradeWindowButton;
   
      [SerializeField] private TMP_Text _pauseText;
   
      private IAudioService _audioService;
      private ISceneManagerService _sceneManagerService;
      private UpgradeView _upgradeView;
      private UpgradeService _upgradeService;

      [Inject]
      public void Construct(IAudioService audioService, ISceneManagerService sceneManagerService, UpgradeView upgradeView, UpgradeService upgradeService)
      {
         _audioService = audioService;
         _sceneManagerService = sceneManagerService;
         _upgradeView = upgradeView;
         _upgradeService = upgradeService;
      }
      
      void OnEnable()
      {
         _pauseButton.onClick.AddListener(OpenPauseMenu);
         _exitButton.onClick.AddListener(ExitFromGamePlay);
         _loseGameButton.onClick.AddListener(LoseGame);
         _plusScoreButton.onClick.AddListener(PlusScore);
         _upgradeWindowButton.onClick.AddListener(OpenUpgradeWindow);
         Counter.Score = 0;
         OnSubscribe();
      }

      private void OnDisable()
      {
         _pauseButton.onClick.RemoveAllListeners();
         _exitButton.onClick.RemoveAllListeners();
         _loseGameButton.onClick.RemoveAllListeners();
         _plusScoreButton.onClick.RemoveAllListeners();
         _upgradeWindowButton.onClick.RemoveAllListeners();
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
         PlayerHealth.OnPlayerWasDied += LoseGame;
      }

      void OnUnsubscribe()
      {
         PlayerHealth.OnPlayerWasDied -= LoseGame;
      }

      void ExitFromGamePlay()
      {
         _audioService.PlayClick();
         _sceneManagerService.LoadMenuScene();
      }

      void LoseGame()
      {
         _audioService.PlayClick();
         _sceneManagerService.LoadEndGameScene();
      }

      void PlusScore()
      {
         _audioService.PlayClick();
         Counter.AddScore();
      }

      void OpenUpgradeWindow()
      {
         var cards = _upgradeService.GenerateCards();
         _upgradeView.Show(cards);
      }
   }
}
