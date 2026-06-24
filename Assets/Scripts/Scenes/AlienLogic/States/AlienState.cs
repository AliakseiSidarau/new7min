namespace DefaultNamespace
{
    public abstract class AlienState
    {
        protected AlienAI ai;

        protected AlienState(AlienAI ai)
        {
            this.ai = ai;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
        
    }
}