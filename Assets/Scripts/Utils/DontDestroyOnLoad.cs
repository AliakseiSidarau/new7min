using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static GameObject _audioManager; 
    void Start()
    {
        if (_audioManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _audioManager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
}
