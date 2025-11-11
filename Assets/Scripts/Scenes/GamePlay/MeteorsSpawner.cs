using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Scenes.GamePlay
{
    public class MeteorsSpawner : MonoBehaviour
    {
        [SerializeField] private Meteor[] _meteors;
        [SerializeField] private float _meteorsSpeed;
        private Vector3 _startPosition;
        private Vector3 _endPoint;
        private Random _rnd;

        public GameObject[] Meteors { get; set; }
    
    
        void Start()
        {
            _startPosition = new Vector3(0f,0f,0f);
            _rnd = new Random(5);
            MakeMetiorits();
        }

        void MakeMetiorits()
        {
            GameObject[] meteor = GameObject.FindGameObjectsWithTag("Meteor");
            if(meteor.Length != _meteors.Length)
            {
                foreach (Meteor meteors in _meteors)
                {
                    _startPosition = new Vector3((_rnd.NextFloat(-3,3)), (_rnd.NextFloat(-5,5)), 0f);
                    Instantiate(meteors, _startPosition, quaternion.RotateZ(3));
                }
            }
        }
    }
}
