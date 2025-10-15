using System;
using Sound;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private WayPointSpawner _currentWayPoint;
        [SerializeField] private GameObject _diamond;
        [SerializeField] private GameObject _player;
        [SerializeField] private Player _playerScript;

       private SoundEffectsPlayer _soundEffectsPlayer;
       private DiamondSpawner _diamondSpawner;
       private Quaternion _angle;
       private float _speed;

       void Start()
       {
           _playerScript = _player.GetComponent<Player>();
           _speed = _playerScript.Speed;
       }

       void Update()
        {
            if (Time.timeScale != 0f)
            {
                if (_currentWayPoint.Target() is null)
                {
                    return;
                }

                _playerScript.MoveToPoint(_currentWayPoint, _speed);
            }
            
            CorrectAngle();
            MakeAPoint();
            ChangeDiamondPosition();
        }

        private void MakeAPoint()
        {
            if (_playerScript.transform.position == _currentWayPoint.Target().transform.position)
            {
                _currentWayPoint.CanMakeNextWayPoint = true;
                
                Destroy(_currentWayPoint.Target().gameObject);
            }
        }

        private void ChangeDiamondPosition()
        {
            if (_playerScript.transform.position == _diamond.transform.position)
            {
                _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
                _diamondSpawner.ChangeDiamondPosition();
                Counter.AddScore();
            }
        }

        private void CorrectAngle()
        {
            if (_playerScript.transform.position != _currentWayPoint.Target().position)
            {
                _angle = Quaternion.Euler(_playerScript.transform.rotation.eulerAngles.x, _playerScript.transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - _playerScript.transform.position.y, _currentWayPoint.Target().position.x - _playerScript.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            
            if (_playerScript.transform.position == _currentWayPoint.Target().position)
            {
                _playerScript.transform.rotation = _angle;
            }
        }
    }
}
