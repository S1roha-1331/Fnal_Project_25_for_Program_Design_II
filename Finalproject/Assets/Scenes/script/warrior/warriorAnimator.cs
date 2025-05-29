using UnityEngine;

public class warriorAnimator : MonoBehaviour
{


    public warriorAttackHitbox AttackHitbox;
    public bool attacking;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setWalking(bool isWalking)
    {
        animator.SetBool("walk",isWalking);
    }
    
    public void triggerAttack()
    {
        animator.ResetTrigger("attack");
        animator.SetTrigger("attack");
    }
    public void triggerHurt()
    {
        animator.ResetTrigger("hurt");
        animator.SetTrigger("hurt");
    }
    public void setDead(bool isDead)
    {
        animator.ResetTrigger("death");
        animator.SetTrigger("death");
    }
    public void triggerSkill()
    {
        animator.ResetTrigger("skill");
        animator.SetTrigger("skill");
    }
    public void startAttack()
    {
        AttackHitbox.colliderEnable();
    }
    public void stopattack()
    {
        AttackHitbox.colliderDisable();
    }
    
}
