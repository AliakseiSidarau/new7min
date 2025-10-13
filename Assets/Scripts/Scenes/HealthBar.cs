using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Scenes
{
    public class HealthBar: MonoBehaviour, IObserver
    {
        [SerializeField] private List<Sprite> _hearths;
        [SerializeField] private Image _image;
        private StarShip _starship;

        private void OnEnable()
        {
            if (_starship != null)
            {
                Subcribe();
            }
        }

        private void Subcribe()
        {
            _starship.HealthChanged += HealthChanged;
            Debug.Log("Subscribe on HealthChanged");
        }

        private void Unsubcribe()
        {
            _starship.HealthChanged -= HealthChanged;
            Debug.Log("Unsubscribe on HealthChanged");
        }
        private void UpdateUI(int health)
        {
            _image.sprite = _hearths[health + 1];
            Debug.Log("Health was changed!");
        }
        
        public void HealthChanged()
        {
            var health = _starship.HealthPoints;
            UpdateUI(health);
        }
    }
}