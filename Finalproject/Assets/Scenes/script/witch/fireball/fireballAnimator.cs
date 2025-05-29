using UnityEngine;

public class fireballAnimator : MonoBehaviour
{
    public fireballFly fireballFly;
    public fireHitbox fireHitbox;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void startMoving()
    {
        fireballFly.startMoving();
    }
    public void openHitbox()
    {
        fireHitbox.colliderEnable();
    }
    public void triggerGone()
    {
        animator.ResetTrigger("gone");
        animator.SetTrigger("gone");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void destroySelf()
    {
        fireballFly.destroySelf();
    }

}
