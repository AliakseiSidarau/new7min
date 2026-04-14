using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class MeteorsSpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Meteor[] meteorPrefabs;

        [Header("Spawn Settings")]
        [SerializeField] private float spawnInterval;
        [SerializeField] private int maxMeteors;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float despawnDistance;

        [Header("Movement")]
        [SerializeField] private Vector2 spaceDrift = new Vector2(1f, 0.2f);
        [SerializeField] private float dangerChance = 0.2f;

        [Header("Size Settings")]
        [SerializeField] private float minScale = 0.7f;
        [SerializeField] private float maxScale = 1.3f;

        [Header("References")]
        [SerializeField] private Transform player;

        private float _timer;
        private readonly List<GameObject> _activeMeteors = new();

        [Inject] private DiContainer _container;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= spawnInterval)
            {
                _timer = 0f;
                TrySpawnMeteor();
            }

            CleanupMeteors();
        }

        private void TrySpawnMeteor()
        {
            if (_activeMeteors.Count >= maxMeteors)
                return;

            SpawnSingleMeteor();
        }

        private void SpawnSingleMeteor()
        {
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.Pow(Random.value, 2f));
            float baseSpeed = Random.Range(1f, 3f);
            float speedMultiplier = 1f / scale;

            Meteor prefab = GetRandomMeteor();

            Vector2 center = player != null ? (Vector2)player.position : Vector2.zero;
            
            Vector2 offset = Random.insideUnitCircle * spawnRadius;

            Vector3 pos = new Vector3(
                center.x + offset.x,
                center.y + offset.y,
                0f
            );

            GameObject meteorGO = _container.InstantiatePrefab(prefab, pos, Quaternion.identity, null);
            
            Vector2 direction;

            if (Random.value < dangerChance)
            {
                direction = ((Vector2)player.position - (Vector2)pos).normalized;
            }
            else
            {
                Vector2 randomDir = Random.insideUnitCircle.normalized;
                direction = (randomDir + spaceDrift).normalized;
            }
            
            Meteor meteor = meteorGO.GetComponent<Meteor>();
            if (meteor != null)
            {
                meteor.SetDirection(direction);
                meteor.SetSpeed(baseSpeed * speedMultiplier);
            }
            
            meteorGO.transform.localScale = Vector3.one * scale;
            meteorGO.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            _activeMeteors.Add(meteorGO);
        }

        private void CleanupMeteors()
        {
            for (int i = _activeMeteors.Count - 1; i >= 0; i--)
            {
                if (_activeMeteors[i] == null)
                {
                    _activeMeteors.RemoveAt(i);
                    continue;
                }

                float distance = Vector2.Distance(
                    _activeMeteors[i].transform.position,
                    player.position
                );

                if (distance > despawnDistance)
                {
                    Destroy(_activeMeteors[i]);
                    _activeMeteors.RemoveAt(i);
                }
            }
        }

        private Meteor GetRandomMeteor()
        {
            int index = Random.Range(0, meteorPrefabs.Length);
            return meteorPrefabs[index];
        }
    }
}