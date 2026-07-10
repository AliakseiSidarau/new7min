using System;
using UnityEngine;
namespace Scenes.GamePlay
{
    [RequireComponent(typeof(Player))]
    public class PlayerFacade : MonoBehaviour, IDamageable

    {
        [SerializeField] private Player _player;
        [SerializeField] private int _startHp = 100;
        private PlayerHealthSystem _playerHealth;
        private IPlayerService _playerService;
        public PlayerHealthSystem PlayerHealth => _playerHealth;
        public int CurrentHP => _playerHealth.CurrentPlayerHP;
        public int MaxHP => _playerHealth.MaxPlayerHP;
        public int Shield => _player.ShieldPoints;

        private void Awake()
        {
            _player ??= GetComponent<Player>();
            _playerHealth = new PlayerHealthSystem(_startHp);
        }

        public void SpeedUp(float value)
        {
            _player.SpeedUp(value);
        }

        public void SpeedDown(float value)
        {
            _player.SpeedDown(value);
        }

        public void Heal(int value)
        {
            _playerHealth.IncreasePlayerHP(value);
        }

        public event Action ShieldChanged

        {
            add => _player.ShieldChanged += value;
            remove => _player.ShieldChanged -= value;
        }

        public event Action<int, int> HealthChanged
        {
            add => _playerHealth.OnHealthChanged += value;
            remove => _playerHealth.OnHealthChanged -= value;
        }

        public event Action PlayerDead
        {
            add => _playerHealth.OnPlayerDead += value;
            remove => _playerHealth.OnPlayerDead -= value;
        }

        public void TakeDamage(int damage)
        {
            _playerHealth.ReducePlayerHP(damage);
        }

    }
}