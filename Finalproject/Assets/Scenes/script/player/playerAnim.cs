using UnityEngine;

public class playerAnim : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void triggerDeath()
    {
        animator.ResetTrigger("death");
        animator.SetTrigger("death");
    }
    public void triggerHurt()
    {
        animator.ResetTrigger("hurt");
        animator.SetTrigger("hurt");
    }
    public void setWalking(bool isWalking)
    {
        animator.SetBool("isWalking",isWalking);
    }
}
