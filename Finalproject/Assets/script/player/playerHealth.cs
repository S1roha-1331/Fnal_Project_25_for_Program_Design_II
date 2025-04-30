using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private playerStats stat;
    public float currentHp;
    Animator anim;
    void Start()
    {
        stat= GetComponent<playerStats>();
        currentHp = stat.getMaxHealth();
        anim = GetComponent<Animator>();
     }
    public void takeDamage(float amount)
    {
        anim.SetBool("hurt",true);
        currentHp-= amount;
        Debug.Log("受到了" + amount + "點傷害");
        if(currentHp <= 0)
        {
            die();
        }
    }
    public void die()
    {
        anim.SetBool("die", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
