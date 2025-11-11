using System;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class CircleMoving : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float movingRadius;
        [SerializeField] private float angularSpeed;
        [SerializeField] private float centerX;
        [SerializeField] private float centerY;
        
        private float _positionX, _positionY, _angle = 0f;

        void Update()
        {
            MovementInACircle();
        }

        public void MovementInACircle()
        {
            _angle += speed * Time.deltaTime;
            
            _positionX = (float)(centerX + Math.Cos(_angle) * movingRadius);
            _positionY = (float)(centerY + Math.Sin(_angle) * movingRadius);
            transform.position = new Vector2(_positionX, _positionY);
            
            
            _angle = _angle + Time.deltaTime * angularSpeed;

            if (_angle >= 360f)
            {
                _angle = 0f;
            }
        }
    }
}