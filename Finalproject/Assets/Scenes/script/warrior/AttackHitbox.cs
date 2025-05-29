using UnityEngine;

public class warriorAttackHitbox : MonoBehaviour
{
    public Collider2D attackCollider;
    public void colliderEnable()
    {
        attackCollider.enabled = true;
    }
    public void colliderDisable()
    {
        attackCollider.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
}