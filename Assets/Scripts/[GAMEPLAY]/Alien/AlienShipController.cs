using Scenes.GamePlay;
using UnityEditor.Tilemaps;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class AlienShipController: MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float attackDistance = 0.2f;
        [SerializeField] private float chaseDistance = 3f;
        [SerializeField] private float rotationRadius = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        
        public Transform Target { get; set; }
        public float AttackDistance => attackDistance;
        public float ChaseDistance => chaseDistance;

        [Inject] private IDamageable _damageable;

        public void MoveTo(Vector3 target)
        {
            Vector2 direction = (target - transform.position).normalized;
            
            transform.position = Vector2.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            RotateTo(direction);
        }

        public float DistanceToTarget()
        {
            return Target == null ? float.MaxValue : Vector2.Distance(transform.position, Target.position);
        }

        public void Attack()
        {
            int damage = Random.Range(5, 16);
            _damageable.TakeDamage(damage);
            Debug.Log($"Alien ship attack!!! - damage taken {damage}");
        }

        private void RotateTo(Vector2 direction)
        {
            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            var angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}