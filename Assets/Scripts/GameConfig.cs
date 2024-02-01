using UnityEngine;

[CreateAssetMenu (fileName = "Config", menuName = "GameData/Config", order = 1)] 
public class GameConfig : ScriptableObject
{
    public float playerSpeed;
    public float playerRotationSpeed;
    public Vector3 startPoint;
}