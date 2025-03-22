using Scenes.GamePlay;
using Sound;
using UnityEngine;

public class StarshipCollisionController : MonoBehaviour
{
    private SoundEffectsPlayer _soundEffectsPlayer;
    private DiamondSpawner _diamondSpawner;
    private GameObject _starShipObj;


    private void Start()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
        _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
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
            Debug.Log("Collision - Meteor!");
        }
        Debug.Log($"{other.name}");
    }
}
