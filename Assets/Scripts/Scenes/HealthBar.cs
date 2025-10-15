using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Scenes
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private List<Sprite> _hearths;
        [SerializeField] private Image _image;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            if (_player != null)
            {
                Subcribe();
            }
        }

        private void OnDisable()
        {
            Unsubcribe();
        }

        private void Subcribe()
        {
            _player.HealthChanged += HealthChanged;
            Debug.Log("Subscribe on HealthChanged");
        }

        private void Unsubcribe()
        {
            _player.HealthChanged -= HealthChanged;
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
                _image.sprite = _hearths[0];
            }
            Debug.Log("Health was changed!");
        }
        
        void HealthChanged()
        {
            var health = _player.HealthPoints;
            UpdateUI(health);
            Debug.Log("HealthBar - HealthChanged!");
        }
    }
}