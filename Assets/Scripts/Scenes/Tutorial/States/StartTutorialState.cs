namespace Scenes.Tutorial
{
    public class StartTutorialState: TutorialState
    {
        public StartTutorialState(TutorialController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            controller.TutorialPanel.SetActive(true);
            controller.StartPopup.SetActive(true);
            controller.MoveMarker.SetActive(false);
            controller.Player.SetActive(false);
            controller.Diamond.SetActive(false);
            controller.TurnButton.SetActive(false);
            controller.InventoryButton.SetActive(false);
            controller.FirstStepTutor.SetActive(true);
        }

        public override void Exit()
        {
            controller.FirstStepTutor.SetActive(false);
        }
    }
}