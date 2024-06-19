
using UnityEngine;
using UnityEngine.UIElements;

public class DiamondSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _diamond;
    private int _count;
    //создать публичный метод который будет отнимать от каунтера 1

    void Start() {

        _count = 0;
            
    }

    void Update()
    {

         if (_count<1)
         {
            _count++;

            GameObject newObj = Instantiate(_diamond, new Vector3(RandomSpawnPosition(), RandomSpawnPosition()), Quaternion.identity);
            newObj.transform.position = new Vector3(RandomSpawnPosition(), RandomSpawnPosition(), 0);
            Debug.Log("Diamond created");
         }

    }

    private float RandomSpawnPosition()
    {

        return Random.Range(-5f, 5f);

    }

}
