using System;
using System.Collections.Generic;
using Scenes;
using Scenes.GamePlay;
using UnityEngine;

public class Player: MonoBehaviour
{ 
   private static int _healthPoints;
   [SerializeField] private int _shieldPoints;
   [SerializeField] private float _speed;
   [SerializeField] private int _healthUpValue;
   [SerializeField] private int _healthDownValue;
   
   private bool _isDestroed;
   private bool _isShieldActive;
   
   public static event Action OnHealthChanged;
   public static event Action OnPlayerWasDied;
   public event Action ShieldChanged;
   
   public static int HealthPoints
   {
      get => _healthPoints;
      set => _healthPoints = value;
   }

   public int ShieldPoints
   {
      get => _shieldPoints;
      set
      {
         if (value >= 0 && value <= _shieldPoints)
         {
            _shieldPoints = value;
            if (_shieldPoints != 0)
            {
               _shieldPoints = value;
               ShieldChanged.Invoke();
               _isShieldActive = true;
            }
         }
         else
         {
            ShieldChanged.Invoke();
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

   public void HealthUp()
   {
      HealthPoints += _healthUpValue;
      OnHealthChanged?.Invoke();
   }

   public void HealthDown()
   {
      HealthPoints -= _healthDownValue;
      OnHealthChanged?.Invoke();
      if (HealthPoints == 0)
      {
         OnPlayerWasDied?.Invoke();
         Debug.Log("Player was died!");
      }
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
