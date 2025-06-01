using Unity.VisualScripting;
using UnityEngine;

public class weaponAnimator : MonoBehaviour
{
    public weaponHitbox hitbox;
    public weaponStat stat;
    public SpriteRenderer weapon;
    public Animator animator;

    private float transparentParameter = .6f;

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
                weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, transparentParameter));//when weapon is inactive
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        setVisibility();
    }



    public void fire()
    {
        animator.ResetTrigger("Fire");
        animator.SetTrigger("Fire");
    }
    public void empty()
    {
        animator.ResetTrigger("Empty");
        animator.SetTrigger("Empty");
    }
    public void reload()
    {
        animator.ResetTrigger("Reload");
        animator.SetTrigger("Reload");
    }
    public void basic()
    {
        animator.ResetTrigger("Basic");
        animator.SetTrigger("Basic");
    }

    public void weaponFire()
    {
        hitbox.weaponFire();
    }
}
