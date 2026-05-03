using UnityEngine;

namespace DefaultNamespace
{
    public class PatrolState: AlienState
    {
        private Vector3 _target;
        private float _waitTimer;
        
        public PatrolState(AlienAI ai) : base(ai)
        {
            PickPoint();
        }

        public override void Update()
        {
            ai.Ship.MoveTo(_target);

            float dist = Vector2.Distance(ai.transform.position, _target);
            
            if (dist < 0.3f)
            {
                _waitTimer -= Time.deltaTime;
                if (_waitTimer <= 0f)
                {
                    PickPoint();
                }
            }

            var player = ai.Sensors.DetectPlayer();
            if (player != null)
            {
                ai.Ship.Target = player;
                ai.ChangeState(new ChaseState(ai));
            }
        }

        private void PickPoint()
        {
            _target = ai.transform.position + (Vector3)Random.insideUnitCircle * 3f;
            _waitTimer = Random.Range(1f, 3f);
        }
    }
}