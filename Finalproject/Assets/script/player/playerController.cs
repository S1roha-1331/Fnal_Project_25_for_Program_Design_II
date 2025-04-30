using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movespeed = 1f;
    Animator anim;

    void Update()
    {
        float moveX = 0f; 
        float moveY = 0f; 
        anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.W)) moveY = 1;
        {
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.S)) moveY = -1;
        {
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("walk", true);
        }
        if (!(Input.anyKey))
        {
            anim.SetBool("walk", false);
        }
        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.Translate(moveDirection * movespeed * Time.deltaTime);
    }
}
