using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class MeteorsSpawner : MonoBehaviour
{
    //[SerializeField] private List<GameObject> _meteorsList = new List<GameObject>();
    [SerializeField] private GameObject[] _meteors;
    [SerializeField] private float _meteorsSpeed;
    private Vector3 _basicPosition;
    
    
    void Start()
    {
        _basicPosition = new Vector3(0f,0f,0f);
        MakeMetiorits();
    }

    void MakeMetiorits()
    {
        GameObject[] meteor = GameObject.FindGameObjectsWithTag("Meteor");
        if(meteor.Length != _meteors.Length)
        {
            float i = 0f;    
            foreach (GameObject meteors in _meteors)
            {
                _basicPosition = new Vector3(i, i, 0f);
                Instantiate(meteors, _basicPosition, quaternion.identity);
                meteors.transform.position = Vector3.up * Time.deltaTime;
                i++;
            }
        }
    }
}
