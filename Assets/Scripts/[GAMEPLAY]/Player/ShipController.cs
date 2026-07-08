using UnityEngine;
using System;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private const float ArrivalThreshold = 0.05f;

    private Transform _cachedTransform;
    private Vector2 _targetPosition;
    private bool _isMoving;

    public event Action OnArrived;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    public void MoveTo(Vector2 targetPosition)
    {
        if (((Vector2)_cachedTransform.position - targetPosition).sqrMagnitude < 0.0001f)
            return;

        _targetPosition = targetPosition;
        _isMoving = true;
    }

    public void Stop()
    {
        _isMoving = false;
    }

    private void Update()
    {
        if (!_isMoving) return;

        _cachedTransform.position = Vector2.MoveTowards(
            _cachedTransform.position,
            _targetPosition,
            _speed * Time.deltaTime
        );

        Vector2 delta = _targetPosition - (Vector2)_cachedTransform.position;
        if (delta.sqrMagnitude < ArrivalThreshold * ArrivalThreshold)
        {
            _isMoving = false;
            OnArrived?.Invoke();
        }
    }
}