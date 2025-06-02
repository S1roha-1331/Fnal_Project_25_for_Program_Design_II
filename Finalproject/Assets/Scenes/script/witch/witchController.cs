using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchController : MonoBehaviour
{
    // Start is called before the first frame update
    public witchStats stats;
    public witchMovement movement;
    public witchAttack attack;
    public Transform player;
    public witchAnimator animator;

    public float attackRange = 5f;
    private bool enterAttack = false;

    private void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        attack.updateCooldown();
        float distance=(Vector3.Distance(transform.position, player.position));
        if (!enterAttack)
        {
            if (distance < attackRange)
            {
                enterAttack = true;
                animator.setWalking(false);
                movement.stop();
            }
            else
            {
                animator.setWalking(true);
                movement.moveTo(player.position);
            }
        }
        else
        {
            if (attack.canCastSpell())
            {
                attack.castRandomSkill();
            }
            if (distance > attackRange + 1f)
            {
                enterAttack = false;
            }
        }    
            
    }
}
