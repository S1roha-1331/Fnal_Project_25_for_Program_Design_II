using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kightstats : MonoBehaviour
{
    public GameObject expBall;
    public float kightHealth;
    public float currentHealth;
    public float kightAttack;
    public float kightSpeed;
    public int gainExp;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = kightHealth;
        anim = GetComponent<Animator>();
    }
    public void takeDamage(float amount)
    {
        anim.SetTrigger("hurt");
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            die();
        }
    }
    public void die()
    {
        anim.SetBool("dead", true);

        GetComponent<DP1>().enabled = false;
        GetComponent<attack>().enabled = false;
        for(int i = 0; i < gainExp; i++)
        {
            Instantiate(expBall, transform.position, Quaternion.identity);
        }
            
        Destroy(gameObject, 2f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
