using UnityEngine;

public class weaponControl: MonoBehaviour
{
    public weaponStat stat;
    public weaponAnimator animator;
    public AttackIndicator indicator;

    public Transform player;

    public float radius = 1.5f;
    private float radian = 6.283f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stat = GetComponent<weaponStat>();
        animator = GetComponentInChildren<weaponAnimator>();
        player = GameObject.FindWithTag("Player").transform;
        indicator = GameObject.FindWithTag("Player").GetComponentInChildren<AttackIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        stat.isnewWeapon();
        stat.conditioniUpdate();
        stat.weaponCDUpdate();

        Vector2 dir = indicator.player.GetAttackDirection();

        if(dir != Vector2.zero)
        {
            transform.position = (Vector2)player.position + (dir.normalized * radius);
            float angle = (stat.weaponTag*(radian/6) + Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
