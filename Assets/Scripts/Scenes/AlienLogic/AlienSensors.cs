using UnityEngine;

namespace DefaultNamespace
{
    public class AlienSensors: MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 6f;
        [SerializeField] private LayerMask playerLayer;

        public Transform DetectPlayer()
        {
            Collider2D hit = Physics2D.OverlapCircle(
                transform.position,
                detectionRadius,
                playerLayer
            );
            return hit ? hit.transform : null;
        }
    }
}