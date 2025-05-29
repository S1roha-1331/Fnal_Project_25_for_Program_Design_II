using UnityEngine;

public class knightAttackJudge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public knightAttack knightAttack;
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            knightAttack.startAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            knightAttack.stopAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
