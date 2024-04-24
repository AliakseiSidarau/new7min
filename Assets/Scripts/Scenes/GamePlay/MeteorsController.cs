using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsController : MonoBehaviour
{
    private Vector3 _vector;
    
    void Start()
    {
        _vector = new Vector3(3, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _vector, 0.01f * Time.deltaTime);
    }
}
