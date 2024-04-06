using UnityEngine;

public class RocketShipController : MonoBehaviour
{
    [SerializeField] private WayPointSpawner _currentWayPoint;
    [SerializeField] private float _shipSpeed;

    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if (_currentWayPoint.Target() == null)
            {
                return;
            }
        
            transform.position = Vector3.MoveTowards(transform.position, _currentWayPoint.Target().position, _shipSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(_currentWayPoint.Target().position.y - transform.position.y, _currentWayPoint.Target().position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        } 
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentWayPoint.CanMakeNextWayPoint = true;
    }
}
