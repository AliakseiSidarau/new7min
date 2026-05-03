using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class AlienShipController: MonoBehaviour
    {
        [SerializeField] private float speed = 1.8f;
        [SerializeField] private float attackDistance = 0.3f;
        [SerializeField] private float chaseDistance = 3.5f;
        [SerializeField] private float rotationRadius = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        
        public Transform Target { get; set; }
        public float AttackDistance => attackDistance;
        public float ChaseDistance => chaseDistance;

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
            if (Target == null) return float.MaxValue;
            return Vector2.Distance(transform.position, Target.position);
        }

        public void Attack()
        {
            Debug.Log("Alien ship attack!!!");
        }

        private void RotateTo(Vector2 direction)
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}