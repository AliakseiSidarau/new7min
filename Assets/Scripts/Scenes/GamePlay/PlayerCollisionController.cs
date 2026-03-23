using Scenes.GamePlay;
using Sound;
using UnityEngine;
using Zenject;

public class PlayerCollisionController : MonoBehaviour
{
    private IAudioService _audioService;
    private DiamondSpawner _diamondSpawner;
    private GameObject _player;
    [SerializeField] private PlayerHealth _playerHealth;

    [Inject]
    public void Construct(IAudioService audioService)
    {
        _audioService = audioService;
    }

    private void OnEnable()
    {
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
            _playerHealth.HealthDown();
            Debug.Log("Collision - Meteor!");
            Debug.Log($"health - {PlayerHealth.HealthPoints}");
        }
        Debug.Log($"{other.name}");
    }
}
