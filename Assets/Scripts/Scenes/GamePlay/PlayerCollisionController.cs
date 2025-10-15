using Scenes.GamePlay;
using Sound;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private SoundEffectsPlayer _soundEffectsPlayer;
    private DiamondSpawner _diamondSpawner;
    private GameObject _player;
    [SerializeField] private Player _playerScript;
    private int _health;


    private void OnEnable()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
        _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
        _health = _playerScript.HealthPoints;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            _health -= 1;
            Debug.Log("Collision - Meteor!");
        }
        Debug.Log($"{other.name}");
    }
}
