using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public event System.Action OnEnergyDepleted;

    public float maxEnergy = 100f;
    public float currentEnergy;

    public float costPerUnit = 1f;

    private void Awake()
    {
        currentEnergy = maxEnergy;
    }

    public bool CanMove(float estimatedDistance)
    {
        return estimatedDistance * costPerUnit <= currentEnergy;
    }

    public void SpendDistance(float distance)
    {
        SpendEnergy(distance * costPerUnit);
    }

    public void SpendEnergy(float amount)
    {
        currentEnergy -= amount;
        currentEnergy = Mathf.Max(0, currentEnergy);

        if (Mathf.Approximately(currentEnergy, 0f))
        {
            OnEnergyDepleted?.Invoke();
        }
    }

    public float CurrentEnergyValue()
    {
        return currentEnergy;
    }

    public void Recharge(float amount)
    {
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy + amount);
    }
}