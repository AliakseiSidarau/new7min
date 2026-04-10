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
        [SerializeField] private float collectDistance = 0.5f;
        [SerializeField] private float energyFromDiamond = 20f;

        [Header("Movement")]
        [SerializeField] private float arrivalThreshold = 0.05f;
        [SerializeField] public float maxEnergyPerMove = 5f;
        
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

                // просто выбираем точку, НЕ двигаемся
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

        // ВЫЗЫВАЕТСЯ КНОПКОЙ UI
        public void ConfirmMove()
        {
            if (!_hasSelection)
                return;

            Vector2 currentPos = player.transform.position;
            float fullCost = energy.CalculateCost(currentPos, _selectedPosition);

            // сколько расстояния можем пройти на текущей энергии
            float usableEnergy = Mathf.Min(energy.currentEnergy, maxEnergyPerMove);
            float maxDistance = usableEnergy / energy.costPerUnit;
            float distanceToTarget = Vector2.Distance(currentPos, _selectedPosition);

            // если энергии хватает — летим в точку
            float usableEnergyConfirm = Mathf.Min(energy.currentEnergy, maxEnergyPerMove);

            if (fullCost <= usableEnergyConfirm)
            {
                float cost = fullCost;
                energy.SpendEnergy(cost);
                _targetPosition = _selectedPosition;
            }
            else
            {
                // иначе летим максимально возможное расстояние
                Vector2 direction = (_selectedPosition - currentPos).normalized;
                _targetPosition = currentPos + direction * maxDistance;

                // тратим ВСЮ энергию
                energy.SpendEnergy(usableEnergyConfirm);
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
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(player.transform.position, _selectedPosition);

                Gizmos.color = Color.green;
                Gizmos.DrawLine(player.transform.position, _previewPosition);

                Gizmos.DrawSphere(_previewPosition, 0.2f);
            }
        }

        private void HandleMovement()
        {
            if (!_isMoving)
                return;

            player.transform.position = Vector2.MoveTowards(
                player.transform.position,
                _targetPosition,
                player.Speed * Time.deltaTime
            );

            RotateTowardsTarget();
            // CheckDiamondCollection();

            if (Vector2.Distance(player.transform.position, _targetPosition) < arrivalThreshold)
            {
                _isMoving = false;
                turnManager.EnterPlanning();
            }
        }

        private void RotateTowardsTarget()
        {
            Vector2 direction = _targetPosition - (Vector2)player.transform.position;

            if (direction.sqrMagnitude < 0.001f)
                return;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            player.transform.rotation = Quaternion.Euler(0, 0, angle);
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
        
        // private void CheckDiamondCollection()
        // {
        //     if (diamond == null) return;
        //
        //     float distance = Vector2.Distance(
        //         player.transform.position,
        //         diamond.position
        //     );
        //
        //     if (distance <= collectDistance)
        //     {
        //         CollectDiamond();
        //     }
        // }
        // private void CollectDiamond()
        // {
        //     Debug.Log("Diamond collected");
        //
        //     energy.Recharge(energyFromDiamond);
        //
        //     diamondSpawner.ChangeDiamondPosition();
        // }
        
        public void OnDiamondCollected()
        {
            energy.Recharge(energyFromDiamond);
        }
    }
}

