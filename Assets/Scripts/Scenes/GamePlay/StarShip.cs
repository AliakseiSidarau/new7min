using Scenes.GamePlay;
using UnityEngine;

public class StarShip: MonoBehaviour

{
   private int _healthPoints;
   private int _shieldPoints;
   private float _speed;
   private bool _isDestroed;
   private bool _isShieldActive;

   public int HealthPoints
   {
      get => _healthPoints;
      set
      {
         if (_healthPoints > 0)
         {
            _healthPoints = value;
            _isDestroed = false;
         }
         else
         {
            Debug.Log("HealthPoints < 0, starship was destroed!");
            _isDestroed = true;
         }
      }
   }

   public int ShieldPoints
   {
      get => _shieldPoints;
      set
      {
         if (_shieldPoints >= 0)
         {
            _shieldPoints = value;
            _isShieldActive = true;
         }
         else
         {
            Debug.Log("ShieldPoints < 0, starships shield inactive!");
            _isShieldActive = false;
         }
      }
   }

   public float Speed
   {
      get => _speed;
      set
      {
         _speed = value;
         Debug.Log($"Speed now is = {_speed}");
      }
   }

   public void MoveToPoint(WayPointSpawner currentWaypoint)
   {
      transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.Target().position, Speed * Time.deltaTime);
      transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(currentWaypoint.Target().position.y - transform.position.y, currentWaypoint.Target().position.x - transform.position.x) * Mathf.Rad2Deg - 90);
   }

   public void SpeedUp(float s)
   {
      Speed = Speed + s;
      Debug.Log($"Speed was UP + {s}");
   }

   public void SpeedDown(float s)
   {
      Speed = Speed - s;
      Debug.Log($"Speed was DOWN - {s}");
   }
}
