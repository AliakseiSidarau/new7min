using System;
using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Data;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class PlayerHealth: MonoBehaviour
    {
        private static int _healthPoints;
        [SerializeField] private int _healthUpValue;
        [SerializeField] private int _healthDownValue;
        
        private ISaveLoadService _saveLoadService;
        
        public static event Action OnHealthChanged;
        public static event Action OnPlayerWasDied;

        public int GetCurrentHealth() => _healthPoints;
        public void SetCurrentHealth(int health) => _healthPoints = health;
        public static int HealthPoints
        {
            get => _healthPoints;
            set => _healthPoints = value;
        }

        [Inject]
        public void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        
        public void HealthUp()
        {
            HealthPoints += _healthUpValue;
            OnHealthChanged?.Invoke();
            _saveLoadService.Save();
        }
        
        public void HealthDown()
        {
            HealthPoints -= _healthDownValue;
            OnHealthChanged?.Invoke();
            _saveLoadService.Save();
            
            if (HealthPoints == 0)
            {
                OnPlayerWasDied?.Invoke();
                Debug.Log("Player was died!");
            }
        }
    }
}