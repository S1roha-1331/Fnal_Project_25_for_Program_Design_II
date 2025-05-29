using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash1 : MonoBehaviour
{
    public Transform player;
    public float normalspeed = 1f;
    public float dashspeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 3f;

    private float dashTimer = 0f;
    private float cooldowntimer = 0f;
    private bool isDashing=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        if (isDashing)
        {
            transform.position += direction * dashspeed * Time.deltaTime;
            dashTimer -= Time.deltaTime;
            if (dashTimer < 0)
            {
                isDashing = false;
                cooldowntimer = dashCooldown;
            }
        }
        else
        {
              
            cooldowntimer -= Time.deltaTime;
            if (cooldowntimer <= 0 && Vector3.Distance(transform.position, player.position) < 10f && Vector3.Distance(transform.position, player.position) > 2f )
            {
                isDashing = true;
                dashTimer = dashDuration;
            }
        }
        
    }
}
