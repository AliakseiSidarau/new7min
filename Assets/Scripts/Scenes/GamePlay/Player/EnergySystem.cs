using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public float maxEnergy = 100f;
    public float currentEnergy;

    public float costPerUnit = 1f;

    private void Awake()
    {
        currentEnergy = maxEnergy;
    }

    public float CalculateCost(Vector2 from, Vector2 to)
    {
        float distance = Vector2.Distance(from, to);
        return distance * costPerUnit;
    }

    public bool CanMove(Vector2 from, Vector2 to)
    {
        return CalculateCost(from, to) <= currentEnergy;
    }

    public void SpendEnergy(float amount)
    {
        currentEnergy -= amount;
        currentEnergy = Mathf.Max(0, currentEnergy);
    }

    public void Recharge(float amount)
    {
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy + amount);
    }
}