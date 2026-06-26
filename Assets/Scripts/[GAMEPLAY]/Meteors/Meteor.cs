using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private LineRenderer predictionLine;
        [SerializeField] private float predictionTime = 1.5f;

        private TurnManager _turnManager;
        private Vector2 direction;
        private bool directionInitialized;

        [Inject]
        public void Construct(TurnManager turnManager)
        {
            _turnManager = turnManager;
        }

        private void Start()
        {
            if (!directionInitialized)
            {
                direction = Random.insideUnitCircle.normalized;
            }

            if (predictionLine != null)
                predictionLine.positionCount = 2;
        }

        private void Update()
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            UpdatePredictionVisibility();
        }

        private void UpdatePrediction()
        {
            Vector2 currentPos = transform.position;
            Vector2 futurePos = currentPos + direction * speed * predictionTime;

            predictionLine.SetPosition(0, currentPos);
            predictionLine.SetPosition(1, futurePos);
        }

        private void UpdatePredictionVisibility()
        {
            if (predictionLine == null || _turnManager == null)
                return;

            if (_turnManager.currentState == TurnManager.GameState.Planning)
            {
                predictionLine.enabled = true;
                UpdatePrediction();
            }
            else
            {
                predictionLine.enabled = false;
            }
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir.normalized;
            directionInitialized = true;
        }
    }
}