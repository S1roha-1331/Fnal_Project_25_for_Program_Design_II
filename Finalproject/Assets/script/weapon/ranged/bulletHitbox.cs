using UnityEngine;

public class bulletHitbox : MonoBehaviour
{
    public weaponBullet bullet;
    public weaponHitbox hitStat;

    void OnTriggerStay2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null && other.CompareTag("Enemy"))
        {
            damageable.takeDamage(hitStat.stat.weaponDamage);
            Debug.Log($"Bullet hit");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GetComponentInParent<weaponBullet>();
        hitStat = bullet.GetComponentInParent<weaponHitbox>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
