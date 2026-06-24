namespace DefaultNamespace
{
    public class ChaseState: AlienState
    {
        public ChaseState(AlienAI ai) : base(ai) {}

        public override void Update()
        {
            var target = ai.Ship.Target;

            if (target == null)
            {
                ai.ChangeState(new PatrolState(ai));
                return;
            }
            
            float dist = ai.Ship.DistanceToTarget();
            
            if (dist < ai.Ship.AttackDistance)
            {
                ai.ChangeState(new AttackState(ai));
                return;
            }
            
            ai.Ship.MoveTo(target.position);
            if (dist < ai.Ship.AttackDistance)
            {
                ai.ChangeState(new AttackState(ai));
                return;
            }
        }
    }
}