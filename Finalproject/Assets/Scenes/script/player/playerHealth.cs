using UnityEngine;

public class playerHealth : MonoBehaviour,IDamageable
{
    private playerStats stats;
    public float currentHp;
    public float maxHp;
    private playerAnim Animator;
    public bool isDead=false;

    void Start()
    {
        stats = GetComponent<playerStats>();
        Animator=GetComponent<playerAnim>();
        stats.OnLevelChanged += HandleLevelUp;
        UpdateMaxHealth();
        currentHp = maxHp;

    }

    void OnDestroy()
    {
        if (stats != null)
            stats.OnLevelChanged -= HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
        OnLevelUp();
    }

    public void takeDamage(float amount)
    {
        Debug.Log($"受到{amount}點傷害");
        Animator.triggerHurt();
        currentHp -= amount;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        Animator.triggerDeath();
        ResultUIManager.instance.showResult();
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
