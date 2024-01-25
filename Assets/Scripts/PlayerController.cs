using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _point;
    private GameObject _player;
    private float _playerSpeed;

    private void MoveToPoint(Vector3 point, float playerSpeed)
    {
        _point = point;
        _playerSpeed = playerSpeed;
        _player.transform.position = Vector3.MoveTowards(transform.position, _point, _playerSpeed * Time.deltaTime);
    }
}
