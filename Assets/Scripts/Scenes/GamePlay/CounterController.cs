using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    public int Counter { get; set; }
  
    void Start()
    {
        _counterText.text = "0";
    }

    void Update()
    {
        _counterText.text = Counter.ToString();
    }
}
