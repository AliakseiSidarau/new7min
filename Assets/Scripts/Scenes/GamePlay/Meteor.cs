using Unity.Collections;
using UnityEditor.UI;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class Meteor : MonoBehaviour
    {
        private float _damage;
        private float _speed;
        private float _health;
        private float _directionX;
        private float _directionY;

        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Health { get; set; }

        private void MoveToDirection(float x, float y)
        {
            transform.Translate(new Vector3(x, y) * Speed * Time.deltaTime);
        }
    }
}