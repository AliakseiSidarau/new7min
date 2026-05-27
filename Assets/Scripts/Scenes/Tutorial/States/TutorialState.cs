namespace Scenes.Tutorial
{
    public abstract class TutorialState
    {
        protected TutorialController controller;

        protected TutorialState(TutorialController controller)
        {
            this.controller = controller;
        }

        public virtual void Enter(){}
        public virtual void Exit(){}
    }
}