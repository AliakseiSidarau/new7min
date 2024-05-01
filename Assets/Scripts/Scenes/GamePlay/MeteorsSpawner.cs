using Unity.Mathematics;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class MeteorsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _meteors;
        [SerializeField] private float _meteorsSpeed;
        private Vector3 _basicPosition;
        private Vector3 _endPoint;

        public GameObject[] Meteors { get; set; }
    
    
        void Start()
        {
            _basicPosition = new Vector3(0f,0f,0f);
            MakeMetiorits();
        }

        void MakeMetiorits()
        {
            GameObject[] meteor = GameObject.FindGameObjectsWithTag("Meteor");
            if(meteor.Length != _meteors.Length)
            {
                float i = 0f;    
                foreach (GameObject meteors in _meteors)
                {
                    _basicPosition = new Vector3(i, i, 0f);
                    Instantiate(meteors, _basicPosition, quaternion.identity);
                    i++;
                }
            }
        }
    }
}
