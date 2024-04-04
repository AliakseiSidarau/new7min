using UnityEngine;

public class WayPointSpawner : MonoBehaviour
{
    private Camera _cam;
    private Vector3 _positionMouse;
    private Vector3 _wayPointPosition;
    [SerializeField] private GameObject _currentWayPoint;
    [SerializeField] private GameObject _starShip;
    private GameObject _prevWayPoint;
    private GameObject _cacheWayPoint;

    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        _positionMouse = Input.mousePosition;
        _positionMouse.z = 2f;
        
        if (Input.GetMouseButtonDown(0))
        {
            ClearWayPoints();
            MakeWayPoints();
        }
         
        // if (Vector3.Distance(_starShip.transform.position, _prevWayPoint.transform.position) < 0.001f)
        // {
        //     Destroy(_prevWayPoint);
        // }
    }
    
    public Transform Target()
    {
        return _cacheWayPoint != null ? _cacheWayPoint.transform : null;
    }

    void MakeWayPoints()
    {
        _wayPointPosition = _cam.ScreenToWorldPoint(_positionMouse);
        _cacheWayPoint = Instantiate(_currentWayPoint, _wayPointPosition, Quaternion.identity);
        _prevWayPoint = _cacheWayPoint;
    }

    void ClearWayPoints()
    {
        if (_prevWayPoint != null)
        {
            Destroy(_prevWayPoint);
        }
    }
}
