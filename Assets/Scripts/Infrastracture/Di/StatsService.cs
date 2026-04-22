using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StatsService
{
   private RuntimeStats _stats;
   public RuntimeStats Stats => _stats;
   
   public void Initialize(GameStats config)
   {
      _stats = new RuntimeStats(config);
   }
}
