using Scenes.GamePlay;
using Sound;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private AudioService _audioService;
    private DiamondSpawner _diamondSpawner;
    private GameObject _player;
    [SerializeField] private Player _playerScript;


    private void OnEnable()
    {
        _audioService = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioService>();
        _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            _audioService.PlayClaim();
            _diamondSpawner.ChangeDiamondPosition();
            Counter.AddScore();
            Debug.Log("Collision - Diamond!");
        }
        
        if (other.gameObject.CompareTag("Meteor"))
        {
            _audioService.PlayBoom();
            _playerScript.HealthDown();
            Debug.Log("Collision - Meteor!");
            Debug.Log($"health - {Player.HealthPoints}");
        }
        Debug.Log($"{other.name}");
    }
}
