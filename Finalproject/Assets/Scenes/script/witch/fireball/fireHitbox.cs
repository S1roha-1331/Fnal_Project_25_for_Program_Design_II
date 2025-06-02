using UnityEngine;

public class fireHitbox : MonoBehaviour
{
    public float damage = 6f;
    public fireballAnimator fireballAnimator;
    public fireballFly fireballFly;
    public Collider2D fireballCollider;
    private playerHealth playerHealth;
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
            if (other.CompareTag("Player"))
            {
                playerHealth.takeDamage(damage);
            }
            fireballFly.endMoving();
            fireballAnimator.triggerGone();          
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        playerHealth = playerObj.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
