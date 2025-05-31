using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightStats : MonoBehaviour, IDamageable
{
    [Header("基本數值")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;

    [Header("技能相關")]//考慮加上普攻攻速
    public float attackDamage;
    public float attackSpeed;// 召喚技能冷卻
    

    public bool isDead = false;
    public int gainExp = 0;
    private knightAnimator animator;
    public GameObject expBall;
    [SerializeField] private GameObject damagePopupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<knightAnimator>();
    }

    // Update is called once per frame
    void Die()
    {
        for (int i = 0; i < gainExp; i++)
        {
            Instantiate(expBall, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    IEnumerator DelayDie()
    {
        yield return new WaitForSeconds(1f);
        Die();
    }
    public void takeDamage(float amount)
    {
        animator.triggerHurt();
        showDamagePopup(amount);
        currentHealth -=amount;
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.setDead(isDead);
            StartCoroutine(DelayDie());
        }
    }
    public void showDamagePopup(float amount)
    {
        Vector3 spawnPos = transform.position + new Vector3(0, 1f, 0);
        GameObject popupGO = Instantiate(damagePopupPrefab, spawnPos, Quaternion.identity);
        popupGO.GetComponent<DamagePopup>().Setup(amount);
    }

}
