using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _currentWayPoint;
    [SerializeField] private GameObject _starShip;
    
    private Camera _cam;
    private Vector3 _positionMouse;
    private Vector3 _wayPointPosition;
    private GameObject _prevWayPoint;
    private GameObject _cacheWayPoint;
    private bool _canMakeNextWayPoint;
    
    public bool CanMakeNextWayPoint { get; set; }

    void Awake()
    {
        _cam = Camera.main;
        CanMakeNextWayPoint = true;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _positionMouse = touch.position;
            _positionMouse.z = 2f;
        }

        else
        {
            _positionMouse = Input.mousePosition;
            _positionMouse.z = 2f;
        }
        
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && CanMakeNextWayPoint)
        {
            ClearWayPoints();
            MakeWayPoints();
        }
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
            CanMakeNextWayPoint = false;
    }

    void ClearWayPoints()
    {
        if (_prevWayPoint != null)
        {
            Destroy(_prevWayPoint);
        }
    }
}
