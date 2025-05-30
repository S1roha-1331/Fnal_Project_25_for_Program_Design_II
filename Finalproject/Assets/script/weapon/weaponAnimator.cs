using Unity.VisualScripting;
using UnityEngine;

public class weaponAnimator : MonoBehaviour
{
    public weaponHitbox hitbox;
    public SpriteRenderer weapon;

    void setVisibility()
    {
        if(hitbox.isAttacking)
        {
            weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 1.0f));
        }
        else
        {
            weapon.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0f));
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = GetComponentInParent<SpriteRenderer>();
        hitbox = weapon.GetComponentInChildren<weaponHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        setVisibility();
    }
}
