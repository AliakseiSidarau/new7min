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
            switch (health)
            {
                case 3:
                    _image.sprite = _hearths[0];
                    break;
                case 2:
                    _image.sprite = _hearths[1];
                    break;
                case 1:
                    _image.sprite = _hearths[2];
                    break;
                case 0:
                    Destroy(this);
                    _image.sprite = _hearths[0];
                    break;
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