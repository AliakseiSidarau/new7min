using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField][Range(0f, 1f)] private float parallaxMultiplier = 0.3f;

    private Vector3 startPosition;
    private Vector3 cameraStartPosition;

    private void Start()
    {
        startPosition = transform.position;
        cameraStartPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - cameraStartPosition;

        transform.position = startPosition + new Vector3(
            delta.x * parallaxMultiplier,
            delta.y * parallaxMultiplier,
            0f
        );
    }
}

