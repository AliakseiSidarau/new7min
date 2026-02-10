using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        transform.position = new Vector2(player.position.x, player.position.y);
    }
}
