using UnityEngine;

public class fireHitbox : MonoBehaviour
{
    public fireballAnimator fireballAnimator;
    public fireballFly fireballFly;
    public Collider2D fireballCollider;
    public void colliderEnable()
    {
        fireballCollider.enabled = true;
    }
    public void colliderDisable()
    {
        fireballCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || (other.CompareTag("Wall")))
        {
            fireballFly.endMoving();
            fireballAnimator.triggerGone();
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
