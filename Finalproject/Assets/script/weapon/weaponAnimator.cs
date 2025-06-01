using Unity.VisualScripting;
using UnityEngine;

public class weaponAnimator : MonoBehaviour
{
    public weaponHitbox hitbox;
    public weaponStat stat;
    public SpriteRenderer weapon;

    //set the visibility of the weapon 
    //if there is no enemy in the attack range of the weapon
    //then the weapon will not appear
    void setVisibility()
    {
        if(hitbox.isAttacking && hitbox.wieldTimer < hitbox.defaultWieldTime)
        {
            weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 1.0f));
            if(hitbox.wieldTimer == 0f)
            {
                weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0.7f));
            }
        }
        else
        {
            weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0f));
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stat = GetComponentInParent<weaponStat>();
        weapon = GetComponent<SpriteRenderer>();
        hitbox = stat.GetComponentInChildren<weaponHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        setVisibility();
    }
}
