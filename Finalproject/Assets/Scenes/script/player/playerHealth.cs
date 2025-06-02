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
        // �q�\�����ܧ�ƥ�
        stats.OnLevelChanged += HandleLevelUp;

        UpdateMaxHealth();
        currentHp = maxHp;

    }

    void OnDestroy()
    {
        // ����O���鬪�|�A�����q�\�ƥ�
        if (stats != null)
            stats.OnLevelChanged -= HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
        // ���ŧ�s�ɷ|�I�s�o��
        OnLevelUp();
    }

    public void takeDamage(float amount)
    {
        Debug.Log($"����{amount}�I�ˮ`");
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
            currentHp = maxHp;  // �ɯŮɦ^��
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
