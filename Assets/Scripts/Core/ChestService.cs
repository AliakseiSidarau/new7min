using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Core;
using Zenject;

public class ChestService
{
    private ITimeService _timeService;
    private readonly List<CheastConfigData> _chestConfigs;

    private CheastState _state;
    public CheastConfigData CurrentConfig => _chestConfigs.First(c => c.Id == _state.CheastId);

    public ChestService(
        ITimeService timeService,
        List<CheastConfigData> chestConfigs
    )
    {
        _timeService = timeService;
        _chestConfigs = chestConfigs;

        CreateNewChest();
    }

    [Inject]
    public void Construct(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public bool CanOpen()
    {
        return _timeService.Now >= _state.UnlockTime;
    }

    public long GetRemainingTime()
    {
        return Math.Max(0, _state.UnlockTime - _timeService.Now);
    }

    private void CreateNewChest()
    {
        var config = _chestConfigs[UnityEngine.Random.Range(0, _chestConfigs.Count)];
        _state = new CheastState()
        {
            CheastId = config.Id,
            UnlockTime = _timeService.Now + config.DelaySeconds
        };
    }
}
