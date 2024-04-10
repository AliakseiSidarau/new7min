using UnityEngine;

[CreateAssetMenu (fileName = "Config", menuName = "GameData/Config", order = 1)] 
public class GameConfig : ScriptableObject
{
    public float shipSpeed;
    public int diamondScore;
    public float meteorSpeed;
    public float meteorRotationSpeed;
}