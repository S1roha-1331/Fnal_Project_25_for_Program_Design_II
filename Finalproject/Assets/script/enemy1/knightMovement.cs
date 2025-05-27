using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightMovement : MonoBehaviour
{
   
    
    public Transform player;

 
    public float pathUpdateInterval = 0.5f;

   
    public float wobbleAmount = 0.5f;
    public float wobbleFrequency = 2f;

    private Vector3 moveDirection = Vector3.zero;
    private float pathTimer = 0f;
    private Vector3 lastPosition;

    private kightstats velocity;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private attack attack;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            GameObject target = GameObject.FindWithTag("Player");
            if (target != null)
            {
                player = target.transform;
            }
            else
            {
                Debug.LogError("找不到 tag 為 'Player' 的主角，請確認主角是否設置了正確的 tag。");
            }
        }
        attack = GetComponent<attack>();
        animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
        velocity = GetComponent<kightstats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack.isAttack)
        {
            return;
        }
        pathTimer-=Time.deltaTime;
        if(pathTimer <= 0f)
        {
            moveDirection=(player.position - transform.position).normalized;
            pathTimer = pathUpdateInterval;
        }
        Vector3 side = Vector3.Cross(moveDirection, Vector3.forward);
        float noise = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) - 0.5f;
        Vector3 wobble = side * noise * wobbleAmount;
        Vector3 finalDirection=(wobble+moveDirection).normalized;
        transform.position += finalDirection * Time.deltaTime * velocity.kightSpeed;
        Vector3 movement = transform.position-lastPosition;
        animator.SetBool("walk", movement.magnitude > 0.01f);

        if (Mathf.Abs(movement.x) > 0.01f)
        {
            spriteRenderer.flipX = movement.x < 0;
        }

        lastPosition = transform.position;
    }
}
