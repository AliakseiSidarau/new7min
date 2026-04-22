public class RuntimeStats
{
    public float speed;
    public float maneuverability;
    public float rotationSpeed;
    public float arrivalThreshold;

    public float maxEnergy;
    public float energyPerDiamond;
    public float maxEnergyPerMove;

    public float shield;
    public float weaponPower;

    public float drawSphereRadius;

    public int diamondForUpgrade;

    public RuntimeStats(GameStats baseStats)
    {
        speed = baseStats.speed;
        maneuverability = baseStats.maneuverability;
        rotationSpeed = baseStats.rotationSpeed;
        arrivalThreshold = baseStats.arrivalThreshold;

        maxEnergy = baseStats.maxEnergy;
        energyPerDiamond = baseStats.energyPerDiamond;
        maxEnergyPerMove = baseStats.maxEnergyPerMove;

        shield = baseStats.shield;
        weaponPower = baseStats.weaponPower;

        drawSphereRadius = baseStats.drawSphereRadius;

        diamondForUpgrade = baseStats.diamondForUpgrade;
    }
}