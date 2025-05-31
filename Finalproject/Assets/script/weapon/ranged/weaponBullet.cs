using UnityEngine;

public class weaponBullet : MonoBehaviour
{
    public weaponHitbox hitStat;
    public weaponStat stat;
    public bulletHitbox bullet;
    public bulletAnimator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitStat = GetComponentInParent<weaponHitbox>();
        stat = hitStat.GetComponentInParent<weaponStat>();
        bullet = GetComponentInParent<bulletHitbox>();
        animator = GetComponentInChildren<bulletAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
