using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.GamePlay
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera cam;
        [SerializeField] private Player player;
        [SerializeField] private EnergySystem energy;
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform moveMarker;
        [SerializeField] private Transform diamond;
        [SerializeField] private DiamondSpawner diamondSpawner;
        [SerializeField] private float collectDistance;
        [SerializeField] private float energyFromDiamond;
        [SerializeField] private float drawSphereRadius; 

        [Header("Movement")]
        [SerializeField] private float arrivalThreshold;
        [SerializeField] public float maxEnergyPerMove;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float maneuverability;
        
        private Vector2 _selectedPosition;
        private bool _hasSelection;

        private Vector2 _targetPosition;
        private Vector2 _previewPosition;
        private bool _isMoving;
        private Vector2 _baseScale;

        private void Start()
        {
            if (cam == null)
                cam = Camera.main;

            turnManager.EnterPlanning();
            
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
            _baseScale = moveMarker.localScale;
        }

        private void Update()
        {
            HandleInput();
            HandleMovement();
            CalculatePreview();
            UpdateLine();
            UpdateMarker();
            AnimateMarker();
        }

        private void HandleInput()
        {
            if (turnManager.currentState != TurnManager.GameState.Planning)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
                _selectedPosition = worldPos;
                _hasSelection = true;
            }
        }
        
        private void UpdateLine()
        {
            if (!_hasSelection)
            {
                lineRenderer.enabled = false;
                return;
            }

            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, _previewPosition);

            float distanceToTarget = Vector2.Distance(player.transform.position, _selectedPosition);
            float maxDistance = Mathf.Min(energy.currentEnergy, maxEnergyPerMove) / energy.costPerUnit;

            if (distanceToTarget <= maxDistance)
                lineRenderer.startColor = lineRenderer.endColor = Color.green;
            else
                lineRenderer.startColor = lineRenderer.endColor = Color.yellow;
        }
        
        public void ConfirmMove()
        {
            if (!_hasSelection)
                return;

            Vector2 currentPos = player.transform.position;
            float fullCost = energy.CalculateCost(currentPos, _selectedPosition);
            
            float usableEnergy = Mathf.Min(energy.currentEnergy, maxEnergyPerMove);
            float maxDistance = usableEnergy / energy.costPerUnit;

            if (fullCost <= usableEnergy)
            {
                float cost = fullCost;
                energy.SpendEnergy(cost);
                _targetPosition = _selectedPosition;
            }
            else
            {
                Vector2 direction = (_selectedPosition - currentPos).normalized;
                _targetPosition = currentPos + direction * maxDistance;
                energy.SpendEnergy(usableEnergy);
            }

            _isMoving = true;
            _hasSelection = false;

            turnManager.EnterExecution();
        }

        private void CalculatePreview()
        {
            if (!_hasSelection)
                return;

            Vector2 currentPos = player.transform.position;
            float usableEnergy = Mathf.Min(energy.currentEnergy, maxEnergyPerMove);
            float maxDistance = usableEnergy / energy.costPerUnit;
            float distanceToTarget = Vector2.Distance(currentPos, _selectedPosition);

            if (distanceToTarget <= maxDistance)
            {
                _previewPosition = _selectedPosition;
            }
            else
            {
                Vector2 direction = (_selectedPosition - currentPos).normalized;
                _previewPosition = currentPos + direction * maxDistance;
            }
        }

        private void OnDrawGizmos()
        {
            if (player == null) return;

            if (_hasSelection)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(player.transform.position, _selectedPosition);

                Gizmos.color = Color.grey;
                Gizmos.DrawLine(player.transform.position, _previewPosition);

                Gizmos.DrawSphere(_previewPosition, drawSphereRadius);
            }
        }

        private void HandleMovement()
        {
            if (!_isMoving)
                return;

            HandleSteering();
            
            player.transform.position += player.transform.up * player.Speed * Time.deltaTime;

            float distance = Vector2.Distance(player.transform.position, _targetPosition);

            if (distance < arrivalThreshold)
            {
                _isMoving = false;
                turnManager.EnterPlanning();
            }
        }
        
        private void HandleSteering()
        {
            Vector2 directionToTarget = _targetPosition - (Vector2)player.transform.position;

            if (directionToTarget.sqrMagnitude < 0.001f)
                return;

            float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90f;

            float currentAngle = player.transform.eulerAngles.z;

            float newAngle = Mathf.MoveTowardsAngle(
                currentAngle,
                targetAngle,
                GetRotationSpeed() * Time.deltaTime
            );

            player.transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        
        private float GetRotationSpeed()
        {
            float min = 60f;   // тяжёлый корабль
            float max = 360f;  // супер манёвренный

            return Mathf.Lerp(min, max, maneuverability);
        }
        
        private void UpdateMarker()
        {
            if (!_hasSelection)
            {
                moveMarker.gameObject.SetActive(false);
                return;
            }

            moveMarker.gameObject.SetActive(true);
            moveMarker.position = _previewPosition;
        }
        private void AnimateMarker()
        {
            float pulse = 1f + Mathf.Sin(Time.time * 5f) * 0.2f;
            moveMarker.localScale = _baseScale * pulse;
        }
        
        public void OnDiamondCollected()
        {
            energy.Recharge(energyFromDiamond);
        }
    }
}

