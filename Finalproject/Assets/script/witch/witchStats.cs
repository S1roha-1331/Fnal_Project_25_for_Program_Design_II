using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchStats : MonoBehaviour
{
    [Header("�򥻼ƭ�")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;
    public float contactDamage = 20f;
    public int gainExp=0;

    [Header("�ޯ����")]
    public float aoe1damage = 5f;
    public float spellCooldown = 5f;        // ���𶡹j
    public float aoeCooldown = 10f;         // �d��ާN�o
    public float aoe2Cooldown = 15f;      // �l��ޯ�N�o

    public bool isDead = false;
    public GameObject expBall;
    public witchAnimator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
        anim.triggerDeath();
        for(int i = 0; i < gainExp; i++)
        {
            Instantiate(expBall, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject, 2f);
    }
}
