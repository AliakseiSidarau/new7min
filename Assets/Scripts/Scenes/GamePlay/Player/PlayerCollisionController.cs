using Scenes.GamePlay;
using Scenes.GamePlay.Upgrade;
using Sound;
using UnityEngine;
using Zenject;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerController _playerController;
    
    private IAudioService _audioService;
    private ProgressService _progress;
    private DiamondSpawner _diamondSpawner;

    [Inject]
    public void Construct(IAudioService audioService, ProgressService progressService, DiamondSpawner diamondSpawner)
    {
        _audioService = audioService;
        _progress = progressService;
        _diamondSpawner = diamondSpawner;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diamond"))
        {
            _audioService.PlayClaim();
            _diamondSpawner.ChangeDiamondPosition();
            
            _progress.AddDiamond();
            
            Debug.Log("Collision - Diamond!");
        }
        
        if (other.CompareTag("Meteor"))
        {
            _audioService.PlayBoom();
            _playerHealth.HealthDown();
            
            Debug.Log("Collision - Meteor!");
        }
    }
}
