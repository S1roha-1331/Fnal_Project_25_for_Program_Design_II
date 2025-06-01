using DG.Tweening;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class weaponHitbox : MonoBehaviour
{
    public bool isAttacking = false;
    //let the weapon lasts for at least 1 sec
    //if there is any enemy in the range
    public float defaultTimer = 1f;
    public float rangeTimer = 1f;

    public float detectRange = 2f;

    public float wieldTimer = 0f;
    public float defaultWieldTime = 0.5f;
    public bool wieldClockwise = true;
    public bool isWielding = false;

    public weaponStat stat;
    public weaponControl control;
    public weaponAnimator visual;
    public attackingHitbox attack;

    public Collider2D weaponCollider;
    public CircleCollider2D weaponRange;
    //public GameObject attackHitbox;
    public GameObject attackRange;

    public Transform player;
    public Transform hitbox;
    public Transform visualTransform;
    //public Transform parent;
    public Transform enemy;

    public GameObject bulletPrefab;

    //redirect the direction of ranged weapon(or melee weapon)
    void rangedRedirect()
    {
        Vector3 turn = new Vector3(0f, 0f, 0f);
        if (!wieldClockwise)
            turn.x = control.twopi / 2;
        visualTransform.localRotation = Quaternion.Euler(turn);
    }

    void meleeWield()
    {
        if (isAttacking && isWielding)
        {
            wieldCDUpdate();
            wieldWeapon();
        }
        else if(stat.attackCooldown <= 0f)
        {
            wieldTimer = 0f;
            wieldTimer += Time.deltaTime;
            isWielding = true;
        }
    }
    void wieldCDUpdate()
    {
        if (0f < wieldTimer && wieldTimer < defaultWieldTime)
            wieldTimer += Time.deltaTime;
        else
        {
            wieldTimer = 0f;
            isWielding = false;
            stat.attackCooldown = stat.defaultCooldown;
        }
    }
    void wieldWeapon()
    {
        float angle = (control.twopi / 4) * (wieldTimer / defaultWieldTime);
        Vector3 turn = new Vector3(0f, 0f, -angle);
        if (!wieldClockwise) 
            turn.x = control.twopi / 2;
        transform.localRotation = Quaternion.Euler(turn);
        visualTransform.localRotation = Quaternion.Euler(turn);
    }

    //have no effect now
    public void colliderUpdate()
    {
        if (weaponCollider.enabled)
        {
            weaponCollider.enabled = false;
        }
        else
        {
            weaponCollider.enabled = true;
        }
    }
    public void rangeUpdate()
    {
        if (weaponRange.enabled)
        {
            weaponRange.enabled = false;
        }
        else
        {
            weaponRange.enabled = true;
        }
    }
    public void hitboxAble()
    {
        //attackHitbox.SetActive(isAttacking);
    }
    public void rangeAble()
    {
        attackRange.SetActive(!stat.isbroken);
    }

    public void bulletEvent()
    {
        if (isAttacking && stat.attackCooldown <= 0f)
            bulletGenerate();
    }
    public void bulletGenerate()
    {
        Vector3 bulletLocate = //transform.position +
            //bulletPrefab.transform.position.x, bulletPrefab.transform.position.y, bulletPrefab.transform.position.x
            new Vector3(0f, 0f, 0f);
        var bulletRotate = Quaternion.Euler(bulletLocate);
        Instantiate(bulletPrefab, transform.position, bulletRotate, transform);
        stat.attackCooldown = stat.defaultCooldown;
        stat.weaponDurability -= stat.downgradePerhit;
    }

    //determine if there is any enemy in the attack range
    void OnTriggerStay2D(Collider2D other)
    {
        if(!stat.isbroken && other.CompareTag("Enemy"))
        {
            isAttacking = true;
        }
        else if(rangeTimer < 0f) 
        {
            isAttacking = false;
            rangeTimer = 1f;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stat = GetComponentInParent<weaponStat>();
        control = GetComponentInParent<weaponControl>();
        visual = control.GetComponentInChildren<weaponAnimator>();
        attack = GetComponentInChildren<attackingHitbox>();

        attackRange = GetComponent<GameObject>();
        //attackHitbox = GetComponentInChildren<>();
        weaponRange = GetComponent<CircleCollider2D>();
        weaponCollider = attack.GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").transform;
        hitbox = weaponCollider.GetComponent<Transform>();
        visualTransform = visual.GetComponent<Transform>();

        if (stat.weaponGenre == WeaponGenre.ranged)
        {
            weaponRange.radius = detectRange;
            weaponCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stat.weaponGenre == WeaponGenre.melee)
            meleeWield();
        else if(stat.weaponGenre == WeaponGenre.ranged)
        {
            rangedRedirect();
            bulletEvent();
        }
        wieldClockwise = control.isClockwise();
        rangeTimer -= Time.deltaTime;

        
    }
}
