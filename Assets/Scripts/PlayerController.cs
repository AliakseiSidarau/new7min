using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _point;
    private GameObject _player;
    private float _playerSpeed;
    private float _playerRotationSpeed;

    private void MoveToPoint(Vector3 point, float playerSpeed, float rotationSpeed)
    {
        _point = point;
        _playerSpeed = playerSpeed;
        _playerRotationSpeed = rotationSpeed;
        
        _player.transform.position = Vector3.MoveTowards(transform.position, _point, _playerSpeed * Time.deltaTime);
        _player.transform.rotation = Quaternion.Euler(0f, 0f, _playerRotationSpeed);
    }
    
}
