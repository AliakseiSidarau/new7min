using System;
using DefaultNamespace;
using Scenes.GamePlay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketShipController : MonoBehaviour
{
    [SerializeField] private WayPointSpawner _currentWayPoint;
    [SerializeField] private float _shipSpeed;
    [SerializeField] private GameObject _diamond;
    private SoundEffectsPlayer _soundEffectsPlayer;

    private void Awake()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
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
            _diamond.SetActive(false);
            Counter.AddScore();
            Debug.Log("Collision - Diamond!");
        }
        
        if (other.gameObject.CompareTag("Meteor"))
        {
            Destroy(this);
            SceneManager.LoadScene("GameOver");
            Debug.Log("Collision - Meteor!");
        }
    }
}
