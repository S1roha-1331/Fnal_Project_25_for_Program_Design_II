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
        // �q�\�����ܧ�ƥ�
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
        // ����O���鬪�|�A�����q�\�ƥ�
=======
>>>>>>> Stashed changes
        if (stats != null)
            stats.OnLevelChanged -= HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
<<<<<<< Updated upstream
        // ���ŧ�s�ɷ|�I�s�o��
=======
>>>>>>> Stashed changes
        OnLevelUp();
    }

    public void takeDamage(float amount)
    {
<<<<<<< Updated upstream
        Debug.Log($"����{amount}�I�ˮ`");
        animator.triggerHurt();
=======
        Debug.Log($"����{amount}�I�ˮ`");
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
