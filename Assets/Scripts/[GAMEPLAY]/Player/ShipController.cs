using UnityEngine;
using System;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 target;
    private bool isMoving;

    public Action OnArrived;

    public void MoveTo(Vector2 targetPosition)
    {
        target = targetPosition;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target) < 0.05f)
        {
            isMoving = false;
            OnArrived?.Invoke();
        }
    }
}