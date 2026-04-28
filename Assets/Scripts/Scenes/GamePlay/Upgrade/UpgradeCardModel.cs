using Scenes.GamePlay.Upgrade;
using Scenes.GamePlay;
using UnityEngine;

public class UpgradeCardModel
{
    public UpgradeType Type;
    public float Value;
    public Sprite Sprite;

    public UpgradeCardModel(UpgradeType type, float value, Sprite sprite = null)
    {
        Type = type;
        Value = value;
        Sprite = sprite;
    }

    public void Apply(ShipModel ship)
    {
        switch (Type)
        {
            case UpgradeType.Speed:
                ship.Speed += Value;
                break;

            case UpgradeType.MaxEnergy:
                ship.MaxEnergy += Value;
                break;

            case UpgradeType.Maneuverability:
                ship.Maneuverability += Value;
                break;

            case UpgradeType.RotationSpeed:
                ship.RotationSpeed += Value;
                break;

            case UpgradeType.MaxEnergyPerMove:
                ship.MaxEnergyPerMove += Value;
                break;

            case UpgradeType.Shield:
                ship.Shield += Value;
                break;

            case UpgradeType.WeaponPower:
                ship.WeaponPower += Value;
                break;
        }
    }
}
