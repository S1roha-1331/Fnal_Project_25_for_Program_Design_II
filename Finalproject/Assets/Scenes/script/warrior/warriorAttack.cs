using UnityEngine;

public class warriorAttack : MonoBehaviour
{
    public bool isAttack;
    public warriorStats warriorStats;
    public warriorAnimator warriorAnimator;
    private float attackCooldown;
    private float attackTimer;
    private float skillTimer;
    [SerializeField] private playerHealth playerHealth;
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
        GameObject player = GameObject.FindWithTag("Player");
        attackCooldown =1/warriorStats.attackSpeed;
        attackTimer = attackCooldown;
        skillTimer=warriorStats.skillCooldown;  
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth target = collision.GetComponentInParent<playerHealth>(); // ? §ï³o¦æ
        if (target != null)
        {
            target.takeDamage(warriorStats.attackDamage);
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
