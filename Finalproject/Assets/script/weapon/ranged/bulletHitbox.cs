using UnityEngine;

public class bulletHitbox : MonoBehaviour
{
    public bulletControl control;
    //public weaponHitbox hitStat;
    public GameObject bullet;
    public Collider2D range;
    public rangeTag tagCS;
    public bulletInt bInt;

    private float destroyTimer = 0f;
    private float destroyTime = 10f;

    void OnTriggerStay2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInParent<IDamageable>();
        if (damageable != null && other.CompareTag("Enemy"))
        {
            damageable.takeDamage(control.weaponDamage);
            Destroy(bullet);
            Debug.Log($"Bullet hit");
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(bullet);
        }
    }
    */
    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger == range)
        {
            Destroy(bullet);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponentInParent<bulletControl>();
        //hitStat = control.GetComponentInParent<weaponHitbox>();
        bullet = control.GetComponentInParent<Transform>().parent.gameObject;
        bInt = bullet.GetComponent<bulletInt>();
        tagCS = bInt.GetComponentInChildren<rangeTag>();
        range = tagCS.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer += Time.deltaTime;

        if (destroyTimer > destroyTime)
        {
            Destroy(bullet);
        }

    }
}
