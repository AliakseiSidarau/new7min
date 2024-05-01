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

    public static int BestScore { get; set; }
  
    void Start()
    {
        _counterText.text = "0";
        BestScore = GetBest(_currentScore);
        _bestScoreText.text = BestScore.ToString();

    }

    void Update()
    {
        _counterText.text = Counter.Score.ToString();
        _currentScore = Counter.ReturnScore();
        BestScore = GetBest(_currentScore);
        _bestScoreText.text = BestScore.ToString();
    }

    private int GetBest( int curScore)
    {
        if (curScore >= BestScore)
        {
            BestScore = curScore;
            return curScore;
        }
        else
        {
            return BestScore;
        } 
    }

    public static int GetBestForLoseScreen()
    {
        return BestScore;
    }
}
