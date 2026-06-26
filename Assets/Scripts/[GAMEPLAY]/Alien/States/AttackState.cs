using UnityEngine;

namespace DefaultNamespace
{
    public class AttackState: AlienState
    {
        private float _cooldown = 0f;
        public AttackState(AlienAI ai) : base(ai) {}

        public override void Update()
        {
            var target = ai.Ship.Target;
            if (target == null)
            {
                ai.ChangeState(new PatrolState(ai));
                return;
            }

            float dist = ai.Ship.DistanceToTarget();
            if (dist > ai.Ship.ChaseDistance)
            {
                ai.ChangeState(new ChaseState(ai));
                return;
            }

            _cooldown -= Time.deltaTime;
            
            if (_cooldown <= 0f)
            {
                ai.Ship.Attack();
                _cooldown = 1.2f;
            }
        }
    }
}