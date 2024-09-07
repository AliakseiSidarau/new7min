using Scenes.GamePlay;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarshipCollisionController : MonoBehaviour
{
    private SoundEffectsPlayer _soundEffectsPlayer;
    private DiamondSpawner _diamondSpawner;
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _shellPoints;
    [SerializeField] private GameObject _hp1;
    [SerializeField] private GameObject _hp2;
    [SerializeField] private GameObject _hp3;
    
    private void Awake()
    {
        _soundEffectsPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectsPlayer>();
        _diamondSpawner = GameObject.FindGameObjectWithTag("DiamondSpawner").GetComponent<DiamondSpawner>();
        _healthPoints = 3;
        _shellPoints = 0;
        _hp1.GetComponent<Renderer>().material.color = Color.green;
        _hp2.GetComponent<Renderer>().material.color = Color.green;
        _hp3.GetComponent<Renderer>().material.color = Color.green;
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
            HealthPointsDown();
            Debug.Log("Collision - Meteor!");
        }
        Debug.Log($"{other.name}");
    }

    void HealthPointsDown()
    {
        _healthPoints--;
        if (_healthPoints == 2)
        {
           _hp1.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(_healthPoints == 1)
        {
            _hp2.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(_healthPoints == 0)
        {
            _hp3.GetComponent<Renderer>().material.color = Color.red;
            Destroy(this);
            SceneManager.LoadScene("GameOver");
        }
    }

    public int GetHealthPoints()
    {
        return _healthPoints;
    }
}
