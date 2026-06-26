using System;
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

            if (energy.CanMove(ship.transform.position, worldPos))
            {
                float cost = energy.CalculateCost(ship.transform.position, worldPos);

                energy.SpendEnergy(cost);

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