using Scenes.GamePlay;
using UnityEngine;
using Zenject;

public class RadiusRenderer : MonoBehaviour
{
    public int segments = 50;
    public Transform target;

    private LineRenderer line;
    
    [Inject] private EnergySystem _energy;
    [Inject] private StatsService _statsService;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.loop = true;
    }

    private void Update()
    {
        if (target == null || line == null) return;

        if (_energy == null || _statsService == null || _statsService.Stats == null)
        {
            return;
        }

        float usableEnergy = Mathf.Min(
            _energy.currentEnergy,
            _statsService.Stats.maxEnergyPerMove
        );

        float actualRadius = usableEnergy / _energy.costPerUnit;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (float)i / segments * Mathf.PI * 2;
            float x = Mathf.Cos(angle) * actualRadius;
            float y = Mathf.Sin(angle) * actualRadius;

            line.SetPosition(i, new Vector3(x, y, 0) + target.position);
        }
    }
}