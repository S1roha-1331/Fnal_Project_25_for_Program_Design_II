using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class weaponControl: MonoBehaviour
{
    public weaponStat stat;
    public weaponHitbox range;
    public weaponAnimator animator;
    public AttackIndicator indicator;

    public Transform player;
    public Vector3 dir;
    public float angle;

    //weapon radius and theta
    private float radius = 2.5f;
    public float twopi = 360f;

    public bool isClockwise()
    {
        float z = transform.rotation.eulerAngles.z;
        if (z >= 90f && z < 270f)
            return false;
        else
            return true;
    }

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
        dir = indicator.player.GetAttackDirection();

        if(dir != Vector3.zero)
        {
            //Vector2 right = Vector2.right;
            float angleOrder = (stat.weaponTag - 1) * (twopi / stat.order.latestWeapon);
            angleOrder *= -1;
            var rotate = Quaternion.Euler(0, 0, angleOrder) * dir;
            transform.position = player.position + rotate.normalized * radius;// * dir.normalized

            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }

        
    }
}
