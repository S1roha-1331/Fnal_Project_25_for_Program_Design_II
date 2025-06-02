using UnityEngine;
using System;

public class playerStats : MonoBehaviour
{
    public float basicHealth;
    public float basicAttack;
    public float finalAttack;
    public float healthPerLevel;
    public PlayerController playerController;
    public static playerStats instance;
    public playerHealth playerHealth;
    private int level = 1;

    private void Awake()
    {
        instance = this;
        finalAttack=basicAttack;
    }
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
    public void increaseAttackI()
    {
        finalAttack += 1;
    }
    public void increaseAttackII()
    {
        finalAttack += 2;
    }
    public void increaseAttackIII()
    {
        finalAttack += 3;
    }
    public void increaseSpeedI()
    {
        playerController.finalSpeed += 1;
    }
    public void increaseSpeedII()
    {
        playerController.finalSpeed += 2;
    }
    public void increaseSpeedIII()
    {
        playerController.finalSpeed += 3;
    }
    public void increaseHealthI()
    {
        playerHealth.maxHp += 100;
        playerHealth.currentHp=playerHealth.maxHp;
    }
    public void increaseHealthII()
    {
        playerHealth.maxHp += 200;
        playerHealth.currentHp = playerHealth.maxHp;
    }
    public void increaseHealthIII()
    {
        playerHealth.maxHp += 300;
        playerHealth.currentHp = playerHealth.maxHp;
    }
}
