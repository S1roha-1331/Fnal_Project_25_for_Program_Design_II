using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorStats : MonoBehaviour
{
    [Header("基本數值")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;

    [Header("技能相關")]//考慮加上普攻攻速
    public float attackDamage;
    public float attackSpeed;// 召喚技能冷卻
    public float skillDamage;
    public float skillCooldown;

    public bool isDead = false;
    public int gainExp = 0;
    private warriorAnimator animator;
    public GameObject expBall;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<warriorAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        animator.setDead(isDead);
        for (int i = 0; i < gainExp; i++)
        {
            Instantiate(expBall, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 2f);
    }
}
