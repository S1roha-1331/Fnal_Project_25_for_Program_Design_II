using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private playerStats stats;
    public float currentHp;
    public float maxHp;
    private Animator anim;

    void Start()
    {
        stats = GetComponent<playerStats>();

        // �q�\�����ܧ�ƥ�
        stats.OnLevelChanged += HandleLevelUp;

        UpdateMaxHealth();
        currentHp = maxHp;

        anim = GetComponent<Animator>();
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
        anim.SetBool("hurt", true);
        currentHp -= amount;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("die", true);
        // �o�̥i�H�[���`�᪺�B�z�޿�
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
