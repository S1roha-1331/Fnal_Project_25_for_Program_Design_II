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
<<<<<<< Updated upstream
        animator=GetComponent<playerAnimator>();
        // ï¿½qï¿½\ï¿½ï¿½ï¿½ï¿½ï¿½Ü§ï¿½Æ¥ï¿½
=======
        Animator=GetComponent<playerAnim>();
>>>>>>> Stashed changes
        stats.OnLevelChanged += HandleLevelUp;
        UpdateMaxHealth();
        currentHp = maxHp;

    }

    void OnDestroy()
    {
<<<<<<< Updated upstream
        // ï¿½ï¿½ï¿½ï¿½Oï¿½ï¿½ï¿½é¬ªï¿½|ï¿½Aï¿½ï¿½ï¿½ï¿½ï¿½qï¿½\ï¿½Æ¥ï¿½
=======
>>>>>>> Stashed changes
        if (stats != null)
            stats.OnLevelChanged -= HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
<<<<<<< Updated upstream
        // ï¿½ï¿½ï¿½Å§ï¿½sï¿½É·|ï¿½Iï¿½sï¿½oï¿½ï¿½
=======
>>>>>>> Stashed changes
        OnLevelUp();
    }

    public void takeDamage(float amount)
    {
<<<<<<< Updated upstream
        Debug.Log($"ï¿½ï¿½ï¿½ï¿½{amount}ï¿½Iï¿½Ë®`");
        animator.triggerHurt();
=======
        Debug.Log($"¨ü¨ì{amount}ÂI¶Ë®`");
        Animator.triggerHurt();
>>>>>>> Stashed changes
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
            currentHp = maxHp;  // ï¿½É¯Å®É¦^ï¿½ï¿½
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
