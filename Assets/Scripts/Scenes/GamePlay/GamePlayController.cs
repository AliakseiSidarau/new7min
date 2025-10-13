using Sound;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class RocketShipController : MonoBehaviour
    {
        [SerializeField] private WayPointSpawner _currentWayPoint;
        [SerializeField] private GameObject _diamond;
        [SerializeField] private GameObject _starshipPrefab;

        public StarShip starship;
        private SoundEffectsPlayer _soundEffectsPlayer;
        private DiamondSpawner _diamondSpawner;
        private Quaternion _angle;
        private GameObject _starshipGameObject;

        void Awake()
        {
            if (_starshipPrefab != null)
            {
                _starshipGameObject = Instantiate(_starshipPrefab);
                Debug.Log("starship game object was created!");
        
                if (!_starshipGameObject.TryGetComponent(out starship))
                {
                    starship = _starshipGameObject.AddComponent<StarShip>();
                }
            }
        }
        void Start()
        {
            starship.Speed = 2f;
            starship.StarShipExtentions();
        }

        void Update()
        {
            if (Time.timeScale != 0f)
            {
                if (_currentWayPoint.Target() is null)
                {
                    return;
                }

                starship.MoveToPoint(_currentWayPoint);
            }
            
            CorrectAngle();
            MakeAPoint();
            ChangeDiamondPosition();
        }

        private void MakeAPoint()
        {
            if (starship.transform.position == _currentWayPoint.Target().transform.position)
            {
                _currentWayPoint.CanMakeNextWayPoint = true;
                
                Destroy(_currentWayPoint.Target().gameObject);
            }
        }

        private void ChangeDiamondPosition()
        {
            if (starship.transform.position == _diamond.transform.position)
            {
                _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
                _diamondSpawner.ChangeDiamondPosition();
                Counter.AddScore();
            }
        }

        private void CorrectAngle()
        {
            if (starship.transform.position != _currentWayPoint.Target().position)
            {
                _angle = Quaternion.Euler(starship.transform.rotation.eulerAngles.x, starship.transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - starship.transform.position.y, _currentWayPoint.Target().position.x - starship.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            
            if (starship.transform.position == _currentWayPoint.Target().position)
            {
                starship.transform.rotation = _angle;
            }
        }
    }
}
