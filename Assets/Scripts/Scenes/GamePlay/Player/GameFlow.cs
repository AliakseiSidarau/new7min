using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public ShipController ship;
    public TurnManager turnManager;

    private void Start()
    {
        ship.OnArrived += OnShipArrived;
    }

    private void OnShipArrived()
    {
        turnManager.EnterPlanning();
    }
}