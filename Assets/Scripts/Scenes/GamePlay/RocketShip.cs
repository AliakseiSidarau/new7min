using UnityEngine;

public class RocketShip: MonoBehaviour

{
    private int _healthPoints;
    private int _shellPoints;
    private float _speed;

    public int HealthPoints
    {
        get
        {
            return _healthPoints;
        }
        set
        {
            if (_healthPoints <= value)
            {
                _healthPoints = 0;
            }
            else
            {
                _healthPoints = value;
            }
        }
    }

    public int ShellPoints
    {
        get
        {
            return _shellPoints;
        }
        set
        {
            if (_shellPoints <= value)
            {
                _shellPoints = 0;
            }
            else
            {
                _shellPoints = value;
            }
        }
    }

    public float Speed { get; set; }

    public int GetHealthPoints()
    {
        return HealthPoints;
    }

    public int GetShellPoints()
    {
        return ShellPoints;
    }
}
