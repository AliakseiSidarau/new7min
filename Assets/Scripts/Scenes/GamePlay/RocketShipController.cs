using DefaultNamespace;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.GamePlay
{
    public class RocketShipController : MonoBehaviour
    {
        [SerializeField] private WayPointSpawner _currentWayPoint;
        [SerializeField] private float _shipSpeed;
        private SoundEffectsPlayer _soundEffectsPlayer;
        private DiamondSpawner _diamondSpawner;
        private Quaternion _angle;

        private void Awake()
        {
            _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
            _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
            _shipSpeed = 2f;
        }

        void Update()
        {
            if (Time.timeScale != 0f)
            {
                if (_currentWayPoint.Target() is null)
                {
                    return;
                }
        
                transform.position = Vector3.MoveTowards(transform.position, _currentWayPoint.Target().position, _shipSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - transform.position.y, _currentWayPoint.Target().position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            }

            if (transform.position != _currentWayPoint.Target().position)
            {
                _angle = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - transform.position.y, _currentWayPoint.Target().position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            }

            if (transform.position == _currentWayPoint.Target().position)
            {
                transform.rotation = _angle;
            }
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("WayPoint"))
            {
                _currentWayPoint.CanMakeNextWayPoint = true;
            }

            if (other.gameObject.CompareTag("Diamond"))
            {
                _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
                _diamondSpawner.ChangeDiamondPosition();
                Counter.AddScore();
                Debug.Log("Collision - Diamond!");
            }
        
            if (other.gameObject.CompareTag("Meteor"))
            {
                _soundEffectsPlayer.PlayBoom(_soundEffectsPlayer.boom);
                Destroy(this);
                SceneManager.LoadScene("GameOver");
                Debug.Log("Collision - Meteor!");
            }
        }
    }
}
