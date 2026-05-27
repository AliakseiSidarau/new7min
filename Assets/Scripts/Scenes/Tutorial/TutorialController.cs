using TMPro;
using UnityEngine;
using UnityEngine.XR;

namespace Scenes.Tutorial
{
    public class TutorialController: MonoBehaviour
    {
        public GameObject StartPopup;
        public GameObject TutorialPanel;
        public GameObject FirstStepTutor;
        public GameObject SecondStepTutor;

        public GameObject MainUI;
        public GameObject Player;
        public GameObject MoveMarker;
        public GameObject Diamond;
        public GameObject TurnButton;
        public GameObject InventoryButton;

        private TutorialState _currentState;

        private void Start()
        {
            ChangeState(new StartTutorialState(this));
        }
        private void ChangeState(TutorialState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void OnStartPopupOk()
        {
            ChangeState(new GamePlayTutorialState(this));
        }

        public void OnTutorialFinish()
        {
            _currentState?.Exit();
            Debug.Log("Tutorial Finished!!!");
        }
    }
}