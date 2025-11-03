using System;
using Scenes.GamePlay;
using Sound;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private SoundEffectsPlayer _soundEffectsPlayer;
    private GameObject _player;
    
    public static event Action OnDiamondWasReceived;

    private void OnEnable()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            _soundEffectsPlayer.PlayClaim(_soundEffectsPlayer.claim);
            OnDiamondWasReceived?.Invoke();
            Debug.Log("Collision - Diamond!");
        }
        
        if (other.gameObject.CompareTag("Meteor"))
        {
            _soundEffectsPlayer.PlayBoom(_soundEffectsPlayer.boom);
            Player.HealthDown();
            Debug.Log("Collision - Meteor!");
            Debug.Log($"health - {Player.HealthPoints}");
        }
        Debug.Log($"{other.name}");
    }
}
