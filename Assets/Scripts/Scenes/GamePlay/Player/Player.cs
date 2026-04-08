using System;
using System.Collections.Generic;
using Scenes;
using Scenes.GamePlay;
using UnityEngine;

public class Player: MonoBehaviour
{ 
   
   [SerializeField] private int _shieldPoints;
   [SerializeField] private float _speed;
   
   
   private bool _isDestroed;
   private bool _isShieldActive;
   
   public event Action ShieldChanged;

   public int ShieldPoints
   {
      get => _shieldPoints;
      set
      {
         if (value >= 0 )
         {
            _shieldPoints = value;
            if (_shieldPoints != 0)
            {
               _shieldPoints = value;
               ShieldChanged?.Invoke();
               _isShieldActive = _shieldPoints > 0;
            }
         }
         else
         {
            ShieldChanged?.Invoke();
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

   public void MoveToPoint(WayPointSpawner currentWaypoint, float Speed)
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
