using UnityEngine;

public class weaponHitbox : MonoBehaviour
{
    public bool isAttacking = false;
    //let the weapon lasts for at least 1 sec
    //if there is any enemy in the range
    public float defaultTimer = 1f;
    public float rangeTimer = 1f;

    public float wieldTimer = 0f;

    public weaponStat stat;
    public weaponControl control;
    public weaponAnimator visual;

    public Collider2D weaponCollider;
    public Collider2D weaponRange;
    //public GameObject attackHitbox;
    public GameObject attackRange;


    public Transform player;
    public Transform hitbox;
    public Transform visualTransform;

    void wieldCDUpdate()
    {
        if (wieldTimer < 1f)
            wieldTimer += Time.deltaTime;
        else
            wieldTimer = 0f;
    }
    public void wieldWeapon()
    {
        float angle = control.twopi * wieldTimer / 4;
        transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        visualTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
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

    //redirect the direction of ranged weapon(or melee weapon)
    public void weaponRedirect()
    {

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
        attackRange = GetComponent<GameObject>();
        //attackHitbox = GetComponentInChildren<>();
        weaponRange = GetComponent<Collider2D>();
        weaponCollider = GetComponentInChildren<Collider2D>();
        player = GameObject.FindWithTag("Player").transform;
        hitbox = weaponCollider.GetComponent<Transform>();
        visualTransform = visual.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rangeTimer -= Time.deltaTime;
        if (isAttacking)
        {
            wieldCDUpdate();
            wieldWeapon();
        }
        else
        {
            wieldTimer = 0f;
        }
    }
}
