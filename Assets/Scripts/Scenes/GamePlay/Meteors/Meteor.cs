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
        
        [Inject]
        public void Construct(TurnManager turnManager)
        {
            _turnManager = turnManager;
        }
        private void Start()
        {
            // случайное направление
            direction = Random.insideUnitCircle.normalized;
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
    }
}