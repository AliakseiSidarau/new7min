using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera cam;
    public ShipController ship;
    public EnergySystem energy;
    public TurnManager turnManager;
    
    private void Update()
    {
        if (turnManager.currentState != TurnManager.GameState.Planning)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);

            float estimatedDistance = Vector2.Distance(ship.transform.position, worldPos);

            if (energy.CanMove(estimatedDistance))
            {
                ship.MoveTo(worldPos);
                turnManager.EnterExecution();
            }
            else
            {
                Debug.Log("Not enough energy");
            }
        }
    }
}