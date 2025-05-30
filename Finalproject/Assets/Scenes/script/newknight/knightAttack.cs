using UnityEngine;

public class knightAttack : MonoBehaviour
{
    public bool isAttack;
    public knightStats knightStats;
    public knightAnimator knightAnimator;
    private float attackCooldown;
    private float attackTimer;
 
    private playerHealth playerHealth;
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
        playerHealth=player.GetComponentInParent<playerHealth>();
        attackCooldown=1/ knightStats.attackSpeed;
        attackTimer = attackCooldown;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.takeDamage(knightStats.attackDamage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isAttack==false) return;
        attackTimer-=Time.deltaTime;
       if (attackTimer < 0)
        {

            knightAnimator.triggerAttack();
            attackTimer = attackCooldown;
        }
    }
}
