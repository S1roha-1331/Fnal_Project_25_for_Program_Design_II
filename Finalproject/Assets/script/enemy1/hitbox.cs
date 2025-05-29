using UnityEngine;

public class hitbox : MonoBehaviour
{
    public SpriteRenderer parentSpriteRenderer;  // 拖曳小怪的SpriteRenderer進來
    private float originalX;
    private attack active;
    private playerHealth hp;
    public bool hasHit=false;

    void Start()
    {
        active=GetComponentInParent<attack>();
        originalX = 0.7f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            hp = player.GetComponent<playerHealth>();
        }
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.x = originalX * (parentSpriteRenderer.flipX ? -1 : 1);
        transform.localPosition = pos;
     
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (active.isActive && !hasHit && col.CompareTag("Player"))
        {
            hasHit = true;
            col.GetComponent<playerHealth>()?.takeDamage(1f);
        }
    }

}
