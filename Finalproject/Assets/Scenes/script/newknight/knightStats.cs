using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightStats : MonoBehaviour, IDamageable
{
    [Header("�򥻼ƭ�")]
    public float maxHealth = 300f;
    public float currentHealth;
    public float moveSpeed = 2f;

    [Header("�ޯ����")]//�Ҽ{�[�W�����t
    public float attackDamage;
    public float attackSpeed;// �l��ޯ�N�o
    

    public bool isDead = false;
    public int gainExp = 0;
    private knightAnimator animator;
    public GameObject expBall;
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
        currentHealth -=amount;
        if(currentHealth <= 0)
        {
            isDead = true;
            animator.setDead(isDead);
            StartCoroutine(DelayDie());
        }
    }

}
