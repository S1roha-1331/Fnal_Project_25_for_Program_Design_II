using UnityEngine;

public class warriorAttack : MonoBehaviour
{
    public bool isAttack;
    public warriorStats warriorStats;
    public warriorAnimator warriorAnimator;
    private float attackCooldown;
    private float attackTimer;
    private float skillTimer;
    [SerializeField] playerHealth playerHealth;
    public void startAttack()
    {
        isAttack = true;
    }
    public void stopAttack()
    {
        isAttack=false;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackCooldown=1/warriorStats.attackSpeed;
        attackTimer = attackCooldown;
        skillTimer=warriorStats.skillCooldown;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.takeDamage(warriorStats.attackDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack==false) return;
        attackTimer-=Time.deltaTime;
        skillTimer-=Time.deltaTime;
        if(skillTimer < 0)
        {
            warriorAnimator.triggerSkill();
            skillTimer = warriorStats.skillCooldown;
        }else if (attackTimer < 0)
        {
            warriorAnimator.triggerAttack();
            attackTimer = attackCooldown;
        }
    }
}
