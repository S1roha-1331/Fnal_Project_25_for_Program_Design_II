using UnityEngine;

public class weaponControl: MonoBehaviour
{
    public weaponStat stat;
    public weaponHitbox range;
    public weaponAnimator animator;
    public AttackIndicator indicator;

    public Transform player;

    //weapon radius and theta
    private float radius = 1.5f;
    public float twopi = 360f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stat = GetComponent<weaponStat>();
        range = GetComponentInChildren<weaponHitbox>();
        animator = GetComponentInChildren<weaponAnimator>();
        player = GameObject.FindWithTag("Player").transform;
        indicator = GameObject.FindWithTag("Player").GetComponentInChildren<AttackIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        //update weapon status
        stat.isnewWeapon();
        stat.conditioniUpdate();
        stat.weaponCDUpdate();

        //set weapon direct by player indicator
        Vector2 dir = indicator.player.GetAttackDirection();

        if(dir != Vector2.zero)
        {
            transform.position = (Vector2)player.position + (dir.normalized * radius);
            float angle = (stat.weaponTag*(twopi/6) + Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
