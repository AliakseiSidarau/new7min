using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Game Stats")]
public class GameStats : ScriptableObject
{
    [Header("Movement")]
    public float speed = 5f;
    public float maneuverability = 0.5f;
    public float rotationSpeed = 5f;
    public float arrivalThreshold = 0.05f;

    [Header("Energy")]
    public float maxEnergy = 100f;
    public float energyPerDiamond = 30f;
    public float maxEnergyPerMove = 10f;

    [Header("Diamond")] public float collectDistance = 0.5f;

    [Header("Combat")]
    public float shield = 0f;
    public float weaponPower = 1f;

    [Header("GUI")] public float drawSphereRadius;

    [Header("Upgrade")] public int diamondForUpgrade = 3;
}
