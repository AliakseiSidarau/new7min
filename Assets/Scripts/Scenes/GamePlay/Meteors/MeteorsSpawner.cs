using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class MeteorsSpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Meteor[] meteorPrefabs;

        [Header("Spawn Settings")]
        [SerializeField] private int count = 5;
        [SerializeField] private float spawnRadius = 12f;

        [Header("References")]
        [SerializeField] private Transform player;

        [Inject] private DiContainer _container;

        private void Start()
        {
            SpawnMeteors();
        }

        private void SpawnMeteors()
        {
            if (meteorPrefabs == null || meteorPrefabs.Length == 0)
            {
                Debug.LogError("No meteor prefabs assigned!");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                SpawnSingleMeteor();
            }
        }

        private void SpawnSingleMeteor()
        {
            // выбираем случайный префаб
            Meteor prefab = GetRandomMeteor();

            // позиция вокруг игрока
            Vector2 center = player != null ? (Vector2)player.position : Vector2.zero;

            Vector2 offset = Random.insideUnitCircle * spawnRadius;

            Vector3 pos = new Vector3(
                center.x + offset.x,
                center.y + offset.y,
                0f
            );

            // создаём через Zenject
            GameObject meteorGO = _container.InstantiatePrefab(prefab, pos, Quaternion.identity, null);

            // случайный поворот
            meteorGO.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // случайный размер
            float scale = Random.Range(0.01f, 0.1f);
            meteorGO.transform.localScale = Vector3.one * scale;

            // если есть логика метеора → можно прокинуть скорость
            Meteor meteor = meteorGO.GetComponent<Meteor>();
            if (meteor != null)
            {
                meteor.SetSpeed(Random.Range(1f, 3f));
            }
        }

        private Meteor GetRandomMeteor()
        {
            int index = Random.Range(0, meteorPrefabs.Length);
            return meteorPrefabs[index];
        }
    }
}