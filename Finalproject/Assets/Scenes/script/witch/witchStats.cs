using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchStats : MonoBehaviour, IDamageable
{
    [Header("基本數值")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;
    public float contactDamage = 20f;
    public int gainExp = 0;

    [Header("技能相關")]
    public float aoe1damage = 5f;
    public float spellCooldown = 5f;        // 普攻間隔
    public float aoeCooldown = 10f;         // 範圍技冷卻
    public float aoe2Cooldown = 15f;      // 召喚技能冷卻

    public int maxCoins = 5;
    private int gainCoins;
    public GameObject coins;
    public string bossName = "witch";
    public bool isDead = false;
    public GameObject expBall;
    public witchAnimator anim;
    [SerializeField] private bossHpBar bossHpBar;
    // Start is called before the first frame update
    void Start()
    {
        gainCoins = Random.Range(0, maxCoins + 1);
        currentHealth = maxHealth;
        bossHpBar.setBossName(bossName);
        bossHpBar.setCurrentHealth(currentHealth);
        bossHpBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame

    void Die()
    {
        for (int i = 0; i < gainCoins; i++)
        {
            Instantiate(coins, transform.position, Quaternion.identity);
        }
        for (int i = 0; i < gainExp; i++)
        {
            Instantiate(expBall, transform.position, Quaternion.identity);
        }
        bossHpBar.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public void takeDamage(float amount)
    {
        anim.triggerHurt();
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);
        bossHpBar.setCurrentHealth(currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
            anim.triggerDeath();
            StartCoroutine(DelayDie());
        }
    }
    IEnumerator DelayDie()
    {
        yield return new WaitForSeconds(1f);
        Die();
    }
}

