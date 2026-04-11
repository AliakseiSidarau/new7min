using System;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class PlayerFacade: MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Player _player;
        
        private IPlayerService _playerService;
        
        public PlayerHealth PlayerHealth => _playerHealth;
        public int Shield => _player.ShieldPoints;
        
        [Inject]
        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void SpeedUp(float value)
        {
            _player.SpeedUp(value);
        }

        public void SpeedDown(float value)
        {
            _player.SpeedDown(value);
        }

        public void TakeDamage(int damage)
        {
            _player.ShieldPoints -= damage;
        }

        // public void MoveTo(WayPointSpawner wayPoint)
        // {
        //     _player.MoveToPoint(wayPoint, _player.Speed);
        // }
        
        public event Action ShieldChanged
        {
            add => _player.ShieldChanged += value;
            remove => _player.ShieldChanged -= value;
        }
    }
}