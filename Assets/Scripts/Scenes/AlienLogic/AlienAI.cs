using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AlienAI : MonoBehaviour
    {
        public AlienShipController Ship;
        public AlienSensors Sensors;
        private AlienState _state;
        private float _thinkTimer = 0f;

        private void Awake()
        {
            if (Ship == null)
                Ship = GetComponent<AlienShipController>();

            if (Sensors == null)
                Sensors = GetComponent<AlienSensors>();
        }

        private void Start()
        {
            ChangeState(new PatrolState(this));
        }

        private void Update()
        {
                _state?.Update();
        }

        public void ChangeState(AlienState newState)
        {
            _state = newState;
            _state?.Enter();
        }
    }
}