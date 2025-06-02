using UnityEngine;

public class playerHealth : MonoBehaviour,IDamageable
{
    private playerStats stats;
    public float currentHp;
    public float maxHp;
    private playerAnimator animator;
    public bool isDead=false;

    void Start()
    {
        stats = GetComponent<playerStats>();
        animator=GetComponent<playerAnimator>();
        // 訂閱等級變更事件
        stats.OnLevelChanged += HandleLevelUp;

        UpdateMaxHealth();
        currentHp = maxHp;

    }

    void OnDestroy()
    {
        // 防止記憶體洩漏，取消訂閱事件
        if (stats != null)
            stats.OnLevelChanged -= HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
        // 等級更新時會呼叫這裡
        OnLevelUp();
    }

    public void takeDamage(float amount)
    {
        Debug.Log($"受到{amount}點傷害");
        animator.triggerHurt();
        currentHp -= amount;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        animator.triggerDeath();
    }

    public void OnLevelUp(bool restoreFullHealth = true)
    {
        UpdateMaxHealth();

        if (restoreFullHealth)  
        {
            currentHp = maxHp;  // 升級時回血
        }
        else
        {
            currentHp = Mathf.Min(currentHp, maxHp);
        }
    }

    private void UpdateMaxHealth()
    {
        maxHp = stats.MaxHealth;
    }
}
