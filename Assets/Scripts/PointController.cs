using UnityEngine;

public class PointController : MonoBehaviour
{
    private GameObject _point;
    private bool _needChangeSide;
    private Vector3 _pointPosition;

    void ChangePosition(Vector3 pointPosition)
    {
        _point.transform.position = _pointPosition;
    }
    
    
}
