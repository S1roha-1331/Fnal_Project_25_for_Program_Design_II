using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorStats : MonoBehaviour, IDamageable
{
    [Header("�򥻼ƭ�")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;

    [Header("�ޯ����")]//�Ҽ{�[�W�����t
    public float attackDamage;
    public float attackSpeed;// �l��ޯ�N�o
    public float skillDamage;
    public float skillCooldown;

    public int maxCoins = 5;
    private int gainCoins;  
    public bool isDead = false;
    public int gainExp = 0;
    private warriorAnimator animator;
    public GameObject expBall;
    public GameObject coins;
    [SerializeField] private GameObject damagePopupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gainCoins = Random.Range(0, maxCoins + 1);
        currentHealth = maxHealth;
        animator = GetComponentInChildren<warriorAnimator>();
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
        Destroy(gameObject);
    }
    public void takeDamage(float amount)
    {
        animator.triggerHurt();
        showDamagePopup(amount);
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.setDead(isDead);
            StartCoroutine(DelayDie());
        }
    }
    IEnumerator DelayDie()
    {
        yield return new WaitForSeconds(1f);
        Die();
    }
    public void showDamagePopup(float amount)
    {
        Vector3 spawnPos = transform.position + new Vector3(0, 1f, 0);
        GameObject popupGO = Instantiate(damagePopupPrefab, spawnPos, Quaternion.identity);
        popupGO.GetComponent<DamagePopup>().Setup(amount);
    }

}
