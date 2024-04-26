using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.GamePlay;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private TMP_Text _bestScoreText;
    private int _currentScore;
    private int _bestScore;
  
    void Start()
    {
        _counterText.text = "0";
        _bestScore = GetBest(_currentScore);
        _bestScoreText.text = _bestScore.ToString();

    }

    void Update()
    {
        _counterText.text = Counter.Score.ToString();
        _currentScore = Counter.ReturnScore();
        _bestScore = GetBest(_currentScore);
        _bestScoreText.text = _bestScore.ToString();

    }

    private int GetBest( int curScore)
    {
        if (curScore >= _bestScore)
        {
            _bestScore = curScore;
            return curScore;
        }
        else
        {
            return _bestScore;
        } 
    }
}
