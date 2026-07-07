using Scenes.GamePlay;
using Sound;
using UnityEngine;
using Zenject;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private PlayerFacade _playerFacade;
    [SerializeField] private PlayerController _playerController;
    
    private IAudioService _audioService;
    private DiamondSpawner _diamondSpawner;
    private GameObject _player;

    [Inject]
    public void Construct(IAudioService audioService, DiamondSpawner diamondSpawner)
    {
        _audioService = audioService;
        _diamondSpawner = diamondSpawner;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            _audioService.PlayClaim();
            _diamondSpawner.ChangeDiamondPosition();
            _playerController.OnDiamondCollected();
            Counter.AddScore();
            Debug.Log("Collision - Diamond!");
        }
        
        if (other.gameObject.CompareTag("Meteor"))
        {
            var damage = Random.Range(1, 21);
            _audioService.PlayBoom();
            _playerFacade.TakeDamage(damage);
            Debug.Log("Collision - Meteor!");
            Debug.Log($"Health - {_playerFacade.CurrentHP}/{_playerFacade.MaxHP}");
        }
        Debug.Log($"{other.name}");
    }
}
