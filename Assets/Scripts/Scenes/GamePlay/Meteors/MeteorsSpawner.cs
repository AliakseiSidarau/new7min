using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class MeteorsSpawner : MonoBehaviour
    {
        [SerializeField] private Meteor meteorPrefab;
        [SerializeField] private int count = 5;
        [SerializeField] private float spawnRangeX = 8f;
        [SerializeField] private float spawnRangeY = 5f;
        
        [Inject] private DiContainer _container;

        private void Start()
        {
            SpawnMeteors();
        }

        private void SpawnMeteors()
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = new Vector3(
                    Random.Range(-spawnRangeX, spawnRangeX),
                    Random.Range(-spawnRangeY, spawnRangeY),
                    0f
                );

                _container.InstantiatePrefab(meteorPrefab, pos, Quaternion.identity, null);
            }
        }
    }
}