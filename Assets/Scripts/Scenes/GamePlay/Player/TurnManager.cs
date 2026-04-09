using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum GameState
    {
        Planning,
        Executing
    }

    public GameState currentState;

    private void Start()
    {
        EnterPlanning();
    }

    public void EnterPlanning()
    {
        currentState = GameState.Planning;
        Time.timeScale = 0f;
    }

    public void EnterExecution()
    {
        currentState = GameState.Executing;
        Time.timeScale = 1f;
    }
}