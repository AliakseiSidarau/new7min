using System;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Scenes.GamePlay
{
    public class DiamondSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _diamond;
        private float _randomRangeX;
        private float _randomRangeY;
        private float _camSizeH;
        private float _camSizeW;
        private Vector3 _pos;
        private Random _rnd;
        void Start()
        {
            ScreenSizeToUnits();
            _rnd = new Random(2);
            _pos = new Vector3((_rnd.NextFloat(-(_camSizeW /2),(_camSizeW /2))), (_rnd.NextFloat(-(_camSizeH/2),(_camSizeH/2))), 0);
            _diamond.transform.position = _pos;
            
            Debug.Log($"H - {_camSizeH}, W - {_camSizeW}");
        }

        private void OnEnable()
        {
            PlayerCollisionController.OnDiamondWasReceived += ChangeDiamondPosition;
        }

        private void OnDisable()
        {
            PlayerCollisionController.OnDiamondWasReceived -= ChangeDiamondPosition;
        }

        public void ChangeDiamondPosition()
        {
            _pos = new Vector3((_rnd.NextFloat(-(_camSizeW /2),(_camSizeW /2))), (_rnd.NextFloat(-(_camSizeH/2),(_camSizeH/2))), 0);
            _diamond.transform.position = _pos;
        }

        void ScreenSizeToUnits()
        {
            _camSizeH = Camera.main.orthographicSize;
            _camSizeW = Camera.main.aspect * _camSizeH;
        }
    }
}
