using System;
using Unity.Collections;
using UnityEditor.UI;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _health;
        
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Health { get; set; }
    }
}