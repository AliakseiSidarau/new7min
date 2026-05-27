namespace Scenes.Tutorial
{
    public class GamePlayTutorialState: TutorialState
    {
        public GamePlayTutorialState(TutorialController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            controller.Player.SetActive(true);
            controller.SecondStepTutor.SetActive(true);
        }

        public override void Exit()
        {
            controller.TutorialPanel.SetActive(false);
            controller.SecondStepTutor.SetActive(false);
            controller.MoveMarker.SetActive(true);
            controller.Player.SetActive(true);
            controller.Diamond.SetActive(true);
            controller.TurnButton.SetActive(true);
            controller.InventoryButton.SetActive(true);
        }
    }
}