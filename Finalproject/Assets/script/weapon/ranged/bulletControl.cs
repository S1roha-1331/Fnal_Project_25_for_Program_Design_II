using System;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    //public weaponHitbox hitStat;
    //public weaponStat stat;
    public bulletHitbox bullet;
    public bulletAnimator animator;
    //public weaponControl weapon;
    public AttackIndicator indicator;

    public Transform player;
    public playerStats playerStat;

    private Vector2 direct;


    public float speed = 0.03f;

    private float statchangePerlevel = .1f;
    public float statchangeParameter = 0f;

    public float defaultDamage = 10f;
    public float weaponDamage = 10f;

    private void Awake()
    {
        //hitStat = GetComponentInParent<weaponHitbox>();
        //stat = hitStat.GetComponentInParent<weaponStat>();
        bullet = GetComponentInChildren<bulletHitbox>();
        animator = GetComponentInChildren<bulletAnimator>();
        //weapon = stat.GetComponentInParent<weaponControl>();


        player = GameObject.FindWithTag("Player").transform;
        playerStat = player.GetComponent<playerStats>();
        indicator = player.GetComponentInChildren<AttackIndicator>();

        direct = indicator.player.GetAttackDirection().normalized;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        statchangeParameter = 1 + (float)Math.Round((playerStat.Level - 1) * statchangePerlevel, 1, MidpointRounding.AwayFromZero);
        weaponDamage = defaultDamage * statchangeParameter;

        //direct = weapon.dir.normalized;

        transform.position += (Vector3)(direct * speed);//  - vectorOffset - playerOffset
        //transform.rotation = Quaternion.Euler(0f, 0f, -angleOffset);
    }
}
