using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public bool isAttack=false;
    public bool isActive=false;
    public hitbox hitbox;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void startAttack()
    {
        GetComponent<Animator>().SetBool("attack",true);
        isAttack = true;
        hitbox.hasHit = false;
    }
    public void stopAttack()
    {
        GetComponent<Animator>().SetBool("attack", false);
        isAttack = false;
    }
    

    public void EnableHitbox()
    {
        isActive = true;
        hitbox.hasHit = false;

        // 這樣即使玩家還站在範圍內也會重新觸發 OnTriggerEnter2D
        Collider2D col = hitbox.GetComponent<Collider2D>();
        col.enabled = false;
        col.enabled = true;
    }

    public void DisableHitbox()
    {
        isActive = false;
    }
    

    // Update is called once per frame
    void Update()
    { 
        if (isAttack)
        {

        }
        
    }
}
