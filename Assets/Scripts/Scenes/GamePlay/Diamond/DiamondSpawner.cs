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

        public void ChangeDiamondPosition()
        {
            float x = UnityEngine.Random.Range(-_camSizeW / 2f, _camSizeW / 2f);
            float y = UnityEngine.Random.Range(-_camSizeH / 2f, _camSizeH / 2f);

            _pos = new Vector3(x, y, 0);
            _diamond.transform.position = _pos;
        }

        void ScreenSizeToUnits()
        {
            _camSizeH = Camera.main.orthographicSize;
            _camSizeW = Camera.main.aspect * _camSizeH;
        }
    }
}
