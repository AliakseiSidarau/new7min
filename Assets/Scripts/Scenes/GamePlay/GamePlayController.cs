using DefaultNamespace;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.GamePlay
{
    public class RocketShipController : MonoBehaviour
    {
        [SerializeField] private WayPointSpawner _currentWayPoint;
        [SerializeField] private GameObject _starship;
        private SoundEffectsPlayer _soundEffectsPlayer;
        private DiamondSpawner _diamondSpawner;
        private Quaternion _angle;

        private void Awake()
        {
            _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
            _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
        }

        void Update()
        {
            if (Time.timeScale != 0f)
            {
                if (_currentWayPoint.Target() is null)
                {
                    return;
                }
        
                _starship.transform.position = Vector3.MoveTowards(_starship.transform.position, _currentWayPoint.Target().position, 1.2f * Time.deltaTime);
                _starship.transform.rotation = Quaternion.Euler(_starship.transform.rotation.eulerAngles.x, _starship.transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - _starship.transform.position.y, _currentWayPoint.Target().position.x - _starship.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            
            CorrectAngle();
            MakeAPoint();
            ChangeDiamondPosition();
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            // if (other.gameObject.CompareTag("Diamond"))
            // {
            //     _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
            //     _diamondSpawner.ChangeDiamondPosition();
            //     Counter.AddScore();
            //     Debug.Log("Collision - Diamond!");
            // }
        
            if (other.gameObject.CompareTag("Meteor"))
            {
                _soundEffectsPlayer.PlayBoom(_soundEffectsPlayer.boom);
                Destroy(this);
                SceneManager.LoadScene("GameOver");
                Debug.Log("Collision - Meteor!");
            }
        }

        private void MakeAPoint()
        {
            if (_starship.transform.position == _currentWayPoint.Target().transform.position)
            {
                _currentWayPoint.CanMakeNextWayPoint = true;
                
                Destroy(_currentWayPoint.Target().gameObject);
            }
        }

        private void ChangeDiamondPosition()
        {
            if (_starship.transform.position == _diamondSpawner._diamondPosition)
            {
                _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
                _diamondSpawner.ChangeDiamondPosition();
                Counter.AddScore();
                Debug.Log(_diamondSpawner._diamondPosition);
            }
        }

        private void CorrectAngle()
        {
            if (_starship.transform.position != _currentWayPoint.Target().position)
            {
                _angle = Quaternion.Euler(_starship.transform.rotation.eulerAngles.x, _starship.transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - _starship.transform.position.y, _currentWayPoint.Target().position.x - _starship.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            
            if (_starship.transform.position == _currentWayPoint.Target().position)
            {
                _starship.transform.rotation = _angle;
            }
        }
    }
}
