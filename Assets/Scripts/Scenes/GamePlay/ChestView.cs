using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class ChestView : MonoBehaviour
{
    [Inject] private ChestService _service;
    
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Image _icon;

    private void Start()
    {
        if (_button != null)
            _button.onClick.AddListener(OnClick);

        UpdateView();
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void OnDestroy()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (!_service.CanOpen())
        {
            Debug.Log("Chest is not ready yet!");
            return;
        }
        
        Debug.Log("Chest was opened!");
        UpdateView();
    }

    private void UpdateView()
    {
        var config = _service.CurrentConfig;

        if (_icon != null)
            _icon.sprite = config.Icon;

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        long remaining = _service.GetRemainingTime();

        if (remaining <= 0)
        {
            _button.gameObject.SetActive(true);
        }
        else
        {
            _button.gameObject.SetActive(false);
            _timerText.text = FormatTime(remaining);
        }
    }

    private string FormatTime(long seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);

        if (time.TotalHours >= 1)
            return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";

        return $"{time.Minutes:D2}:{time.Seconds:D2}";
    }
}