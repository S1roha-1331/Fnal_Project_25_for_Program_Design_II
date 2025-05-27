using UnityEngine;
using System;

public class playerStats : MonoBehaviour
{
    public float basicHealth;
    public float basicAttack;
    public float healthPerLevel;

    private int level = 1;
    public int Level
    {
        get => level;
        set
        {
            if (value > 0 && value != level)
            {
                level = value;      
                // 觸發事件通知外界等級改變
                OnLevelChanged?.Invoke(level);
            }
        }
    }

    public float MaxHealth
    {
        get
        {
            return basicHealth + (level - 1) * healthPerLevel;
        }
    }

    // 宣告事件，訂閱此事件來取得等級變更通知
    public event Action<int> OnLevelChanged;
}
