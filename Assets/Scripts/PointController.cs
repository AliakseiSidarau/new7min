using UnityEngine;
using Random = System.Random;

public class PointController : MonoBehaviour
{
    // private GameObject _point;
    // private bool _needChangeSide;
    // private Vector3 _pointPosition;
    // private static Vector3 _coordinate1 = new Vector3(0f, 4.125f, 1f);
    // private static Vector3 _coordinate2 = new Vector3(-1f, 4.125f, 1f);
    // private static Vector3 _coordinate3 = new Vector3(1f, 4.125f, 1f);
    // private static Vector3 _coordinate4 = new Vector3(-2f, 4.125f, 1f);
    // private static Vector3 _coordinate5 = new Vector3(2f, 4.125f, 1f);
    //
    // private static Vector3 _coordinate6 = new Vector3(0f, -4.125f, 1f);
    // private static Vector3 _coordinate7 = new Vector3(-1f, -4.125f, 1f);
    // private static Vector3 _coordinate8 = new Vector3(1f, -4.125f, 1f);
    // private static Vector3 _coordinate9 = new Vector3(-2f, -4.125f, 1f);
    // private static Vector3 _coordinate10 = new Vector3(2f, -4.125f, 1f);
    //
    // private Vector3[] _coordinatesForTopPoints = {_coordinate1, _coordinate2, _coordinate3, _coordinate4, _coordinate5};
    //
    // private Vector3[] _coordinatesForBottomPoints = { _coordinate6, _coordinate7, _coordinate8, _coordinate9, _coordinate10 };
    // private Random rnd = new Random();
    //
    // void ChangeTopPosition(Vector3 pointPosition)
    // {
    //     _point.transform.position = _coordinatesForTopPoints[rnd.Next(0,4)];
    // }
    //
    // void ChangeBottomPosition(Vector3 pointPosition)
    // {
    //     _point.transform.position = _coordinatesForBottomPoints[rnd.Next(0,4)];
    // }
    //
    
    [SerializeField] private GameObject topPoint;
    [SerializeField] private GameObject bottomPoint;

    private Vector3 TopPointPosition;
    private Vector3 BottomPointPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("TopPoint"))
        {
            topPoint.SetActive(false);
            bottomPoint.transform.position = BottomPointPosition;
            bottomPoint.SetActive(true);
           
        }
        else if(gameObject.CompareTag("BottomPoint"))
        {
            bottomPoint.SetActive(false);
            topPoint.transform.position = TopPointPosition;
            topPoint.SetActive(true);
        }
        else
        {
            Debug.LogError("Tag wasn't find!!!");
        }
    }


    void FixedUpdate()
    {
        RandomPosition();
    }

    void RandomPosition()
    {
        Random rnd = new Random();
        TopPointPosition = new Vector3(rnd.Next(-2, 2), 4.125f, 0);
        BottomPointPosition = new Vector3(rnd.Next(-2, 2), -4.125f, 0);
    }
}
