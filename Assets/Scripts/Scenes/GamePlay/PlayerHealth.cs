using System;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Data;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class PlayerHealth: MonoBehaviour
    {
        private static int _healthPoints;
        [SerializeField] private int _healthUpValue;
        [SerializeField] private int _healthDownValue;
        
        public static event Action OnHealthChanged;
        public static event Action OnPlayerWasDied;

        public int GetCurrentHealth() => _healthPoints;
        public void SetCurrentHealth(int health) =>
            _healthPoints = health;
        public static int HealthPoints
        {
            get => _healthPoints;
            set => _healthPoints = value;
        }
        
        public void HealthUp()
        {
            HealthPoints += _healthUpValue;
            OnHealthChanged?.Invoke();
        }
        
        public void HealthDown()
        {
            HealthPoints -= _healthDownValue;
            OnHealthChanged?.Invoke();
            if (HealthPoints == 0)
            {
                OnPlayerWasDied?.Invoke();
                Debug.Log("Player was died!");
            }
        }
    }
}