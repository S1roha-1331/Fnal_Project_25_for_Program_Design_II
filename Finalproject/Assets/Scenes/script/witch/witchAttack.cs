using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchAttack : MonoBehaviour
{
    public float fireballCooldown = 3f;
    public float aoe1Cooldown = 5f;
    public float aoe2Cooldown = 8f;
    public witchAnimator animator;
    

    private float fireballTimer = 0f;
    private float aoe1Timer = 0f;
    private float aoe2Timer = 0f;

    

    public void updateCooldown()
    {
        fireballTimer-=Time.deltaTime;
        aoe1Timer-=Time.deltaTime;
        aoe2Timer-=Time.deltaTime;
    }
    public bool canCastSpell()
    {
        return fireballTimer <= 0f || aoe1Timer <= 0f || aoe2Timer <= 0f;
    }
    public void castRandomSkill()
    {
        List<System.Action> availableSkills = new List<System.Action>();

        if (fireballTimer <= 0f) availableSkills.Add(castFireball);
        if (aoe1Timer <= 0f) availableSkills.Add(castAoe1);
        if (aoe2Timer <= 0f) availableSkills.Add(castAoe2);

        if (availableSkills.Count == 0) return;

        int i = Random.Range(0, availableSkills.Count);
        availableSkills[i].Invoke();
    }
    void castFireball()
    {
        fireballTimer = fireballCooldown;
        animator.triggerFireball();
    }
    void castAoe1()
    {
        aoe1Timer = aoe1Cooldown;
        animator.triggerAoe1();     
    }
   
    void castAoe2()
    {
        aoe2Timer = aoe2Cooldown;
        animator.triggerAoe2();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
