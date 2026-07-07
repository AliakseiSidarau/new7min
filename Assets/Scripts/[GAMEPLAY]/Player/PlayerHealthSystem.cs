using System;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class PlayerHealthSystem
    {
        public int MaxPlayerHP { get; private set; }
        public int CurrentPlayerHP { get; private set; }
        public bool IsDead => CurrentPlayerHP <= 0;

        public event Action<int, int> OnHealthChanged;
        public event Action OnPlayerDead;

        public PlayerHealthSystem(int maxPlayerHP)
        {
            MaxPlayerHP = Mathf.Max(1, maxPlayerHP);
            CurrentPlayerHP = MaxPlayerHP;
        }

        public void ReducePlayerHP(int value)
        {
            if (value <= 0 || IsDead)
                return;

            CurrentPlayerHP = Mathf.Max(0, CurrentPlayerHP - value);
            OnHealthChanged?.Invoke(CurrentPlayerHP, MaxPlayerHP);

            if (CurrentPlayerHP == 0)
            {
                OnPlayerDead?.Invoke();
            }
        }

        public void IncreasePlayerHP(int value)
        {
            if (value <= 0 || IsDead)
                return;

            CurrentPlayerHP = Mathf.Min(MaxPlayerHP, CurrentPlayerHP + value);
            OnHealthChanged?.Invoke(CurrentPlayerHP, MaxPlayerHP);
        }

        public void ChangeMaxPlayerHP(int value)
        {
            MaxPlayerHP = Mathf.Max(1, MaxPlayerHP + value);
            CurrentPlayerHP = Mathf.Min(CurrentPlayerHP, MaxPlayerHP);
            OnHealthChanged?.Invoke(CurrentPlayerHP, MaxPlayerHP);
        }

        public void RestoreFullHP()
        {
            CurrentPlayerHP = MaxPlayerHP;
            OnHealthChanged?.Invoke(CurrentPlayerHP, MaxPlayerHP);
        }
    }
}