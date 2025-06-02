using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchAnimator : MonoBehaviour
{
    public GameObject aoe1Prefab;
    public GameObject fireballPrefab;
    public float rightspawnX = 0f;
    public float rightspawnY = 0f;
    public float leftspawnX = 0f;
    public float leftspawnY = 0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private witchFlip isRight;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = GetComponentInParent<witchFlip>();
    }
    public void aoe1()
    {
        Vector3 offset;
        if (isRight.facingRight)
        {
            offset = new Vector3(rightspawnX, rightspawnY, 0);
        }
        else
        {
            offset = new Vector3(leftspawnX, leftspawnY, 0);
        }
        Vector3 spawnposition = transform.position + offset;
        GameObject aoeObj= Instantiate(aoe1Prefab, spawnposition, Quaternion.identity);
        aoe1Flip aoe1Flip=aoeObj.GetComponent<aoe1Flip>();
        aoe1Flip.SetDirection(isRight.facingRight);

    }
    public void fireball()
    {
        Vector3 offset;
        if (isRight.facingRight)
        {
            offset = new Vector3(rightspawnX, rightspawnY, 0);
        }
        else
        {
            offset = new Vector3(leftspawnX, leftspawnY, 0);
        }
        Vector3 baseSpawnPosition = transform.position + offset;

        // 隨機決定要生成幾顆火球（3~5）
        int fireballCount = UnityEngine.Random.Range(3, 6); // 上限是「不包含」6

        for (int i = 0; i < fireballCount; i++)
        {
            // 每顆火球的隨機偏移（例如 x ±0.5, y ±0.3）
            Vector3 randomOffset = new Vector3(
                UnityEngine.Random.Range(-2, 2f),
                UnityEngine.Random.Range(-1f, 1f),
                0f
            );

            Vector3 spawnPosition = baseSpawnPosition + randomOffset;
            GameObject aoeObj = Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);

            // 若你想讓火球一生成就開始移動，可以加：
            aoeObj.GetComponent<fireballFly>()?.startMoving();
        }

    }
    public void setWalking(bool isWalking)
    {
        animator.SetBool("walk", isWalking);
    }
    
    public void triggerFireball()
    {
        animator.ResetTrigger("fireball");
        animator.SetTrigger("fireball");
    }
    public void triggerAoe1()
    {
        animator.ResetTrigger("aoe1");
        animator.SetTrigger("aoe1");
    }
    public void triggerAoe2()
    {
        animator.ResetTrigger("aoe2");
        animator.SetTrigger("aoe2");
    }

    public void triggerHurt()
    {
        animator.ResetTrigger("hurt");
        animator.SetTrigger("hurt");
    }

    public void triggerDeath()
    {
        animator.SetTrigger("death");
    }

   
}
