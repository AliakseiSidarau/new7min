using System;
using System.Collections.Generic;
using Scenes;
using Scenes.GamePlay;
using UnityEngine;

public class StarShip: MonoBehaviour, ISubject
{
   private int _healthPoints;
   private int _shieldPoints;
   private float _speed;
   private bool _isDestroed;
   private bool _isShieldActive;

   private List<IObserver> _observers = new List<IObserver>();

   public event Action HealthChanged;
   
   public int HealthPoints
   {
      get => _healthPoints;
      set
      {
         if (value >= 0 && value <= _healthPoints)
         {
            _healthPoints = value;
            if (HealthChanged != null)
            {
               HealthChanged.Invoke();
            }
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

   public void Attach(IObserver observer)
   {
      _observers.Add(observer);
      Debug.Log($"New observer - {observer} was added.");
   }

   public void Detach(IObserver observer)
   {
      _observers.Remove(observer);
      Debug.Log($"Observer - {observer} was removed.");
   }
}
