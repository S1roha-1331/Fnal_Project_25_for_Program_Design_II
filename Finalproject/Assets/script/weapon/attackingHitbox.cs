using UnityEngine;

public class attackingHitbox : MonoBehaviour
{
    public weaponStat stat;
    public weaponHitbox hitStat;

    
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (hitStat.isAttacking && stat.attackCooldown <= 0f)
        {
            
            IDamageable damageable = other.GetComponentInParent<IDamageable>();
            if (damageable != null && other.CompareTag("Enemy"))//
            {
                damageable.takeDamage(stat.weaponDamage);
                stat.attackCooldown = stat.defaultCooldown;
                stat.weaponDurability -= stat.downgradePerhit;
                //hitStat.isWielding = true;
                Debug.Log($"weapon attacking");
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stat = GetComponentInParent<weaponStat>();
        hitStat = GetComponentInParent<weaponHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
