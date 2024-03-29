using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private GameObject _point;
    [SerializeField] private Button _fieldButton;
    
    private float _playerSpeed = 3f;
    private float _playerRotationSpeed = 3f;
    private bool _needToMove;
    
    
    void Start()
    {
        _fieldButton.onClick.AddListener(MoveToPoint);
    }

    void FixedUpdate()
    {
        MoveToPoint();
    }

    void MoveToPoint()
    {
        if(_needToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point.transform.position, _playerSpeed * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0f, 0f, _playerRotationSpeed);
            Debug.Log("Button Clicked!!!");
            ChangeNeedToMove();
        }
        
    }

    void ChangeNeedToMove()
    {
        _needToMove = !_needToMove;
    }
}
