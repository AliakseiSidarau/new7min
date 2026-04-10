using UnityEngine;

namespace Scenes.GamePlay
{
    public class DiamondSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _diamond;
        [SerializeField] private Transform player;
        [SerializeField] private float spawnRadius = 10f;

        private void Start()
        {
            ChangeDiamondPosition(); 
        }

        public void ChangeDiamondPosition()
        {
            if (player == null)
            {
                Debug.LogError("Player not assigned in DiamondSpawner!");
                return;
            }

            Vector2 center = player.position;

            float x = Random.Range(center.x - spawnRadius, center.x + spawnRadius);
            float y = Random.Range(center.y - spawnRadius, center.y + spawnRadius);

            _diamond.transform.position = new Vector3(x, y, 0f);
        }
    }
}