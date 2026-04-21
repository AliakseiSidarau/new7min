using Scenes.GamePlay.Upgrade;
using UnityEngine;

public class CardsModel
{
    public UpgradeType Type;
    public float Value;
    public Sprite Sprite;

    public CardsModel(UpgradeType type, float value, Sprite sprite = null)
    {
        Type = type;
        Value = value;
        Sprite = sprite;
    }
}
