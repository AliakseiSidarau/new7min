using System;
using Sound;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private WayPointSpawner _currentWayPoint; 
        [SerializeField] private GameObject _playerGO;
        private Quaternion _angle;
        private float _speed;
        private Player _playerClass;

       void Awake()
       {
           _playerClass = _playerGO.GetComponent<Player>();
           _speed = Player.Speed;
       }

       void Update()
        {
            if (Time.timeScale != 0f)
            {
                if (_currentWayPoint.Target() is null)
                {
                    return;
                }

                _playerClass.MoveToPoint(_currentWayPoint, _speed);
            }
            
            CorrectAngle();
            MakeAPoint();
        }

        private void MakeAPoint()
        {
            if (_playerClass.transform.position == _currentWayPoint.Target().transform.position)
            {
                _currentWayPoint.CanMakeNextWayPoint = true;
                
                Destroy(_currentWayPoint.Target().gameObject);
            }
        }
        
        private void CorrectAngle()
        {
            if (_playerClass.transform.position != _currentWayPoint.Target().position)
            {
                _angle = Quaternion.Euler(_playerClass.transform.rotation.eulerAngles.x, _playerClass.transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - _playerClass.transform.position.y, _currentWayPoint.Target().position.x - _playerClass.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            
            if (_playerClass.transform.position == _currentWayPoint.Target().position)
            {
                _playerClass.transform.rotation = _angle;
            }
        }
    }
}
