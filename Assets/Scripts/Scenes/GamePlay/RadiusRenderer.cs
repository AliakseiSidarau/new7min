using Scenes.GamePlay;
using UnityEngine;

public class RadiusRenderer : MonoBehaviour
{
    public int segments = 50;
    public float radius = 5f;
    public Transform target;

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.loop = true;
    }

    private void Update()
    {
        if (target == null) return;

        float usableEnergy = Mathf.Min(
            FindObjectOfType<EnergySystem>().currentEnergy,
            FindObjectOfType<PlayerController>().maxEnergyPerMove
        );

        float actualRadius = usableEnergy / FindObjectOfType<EnergySystem>().costPerUnit;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (float)i / segments * Mathf.PI * 2;
            float x = Mathf.Cos(angle) * actualRadius;
            float y = Mathf.Sin(angle) * actualRadius;

            line.SetPosition(i, new Vector3(x, y, 0) + target.position);
        }
    }
}