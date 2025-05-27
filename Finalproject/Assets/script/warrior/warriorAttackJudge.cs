using UnityEngine;

public class warriorAttackJudge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public warriorAttack warriorAttack;
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            warriorAttack.startAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            warriorAttack.stopAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
