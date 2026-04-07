using System.Collections.Generic;
using Scenes.GamePlay;
using UnityEngine;
using UnityEngine.UI;


namespace Scenes
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private List<Sprite> _hearths;
        [SerializeField] private Image _image;

        private void OnEnable()
        {
            PlayerHealth.HealthPoints = 3;
            UpdateUI(PlayerHealth.HealthPoints);
            Subcribe();
            
        }

        private void OnDisable()
        {
            Unsubcribe();
        }

        private void Subcribe()
        {
            PlayerHealth.OnHealthChanged += HealthChanged;
            Debug.Log("Subscribe on HealthChanged");
        }

        private void Unsubcribe()
        {
            PlayerHealth.OnHealthChanged -= HealthChanged;
            Debug.Log("Unsubscribe on HealthChanged");
        }
        private void UpdateUI(int health)
        {
            if (health == 3)
            {
                _image.sprite = _hearths[0];
            }
            else if (health == 2)
            {
                _image.sprite = _hearths[1];
            }
            else if (health == 1)
            {
                _image.sprite = _hearths[2];
            }
            else if (health == 0)
            {
                Destroy(this);
                _image.sprite = _hearths[0];
            }
            Debug.Log("Health was changed!");
        }
        
        void HealthChanged()
        {
            var health = PlayerHealth.HealthPoints;
            UpdateUI(health);
            Debug.Log("HealthBar - HealthChanged!");
        }
    }
}