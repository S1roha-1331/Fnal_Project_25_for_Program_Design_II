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
                // Ĳ�o�ƥ�q���~�ɵ��ŧ���
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

    // �ŧi�ƥ�A�q�\���ƥ�Ө��o�����ܧ�q��
    public event Action<int> OnLevelChanged;
}
