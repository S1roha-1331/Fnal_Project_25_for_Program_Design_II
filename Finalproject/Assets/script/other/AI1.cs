using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class AI1 : MonoBehaviour
{
    public Transform player;
    public float normalSpeed = 3f;
    public float dashSpeed = 8f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    public float wobbleAmplitude = 1f;
    public float wobbleFrequency = 2f;
    public float pauseChance = 0.01f;
    public float pauseDuration = 0.5f;

    public float attackRange = 6f;      // 進入攻擊模式的範圍
    public float tooCloseRange = 2.5f;  // 進入迴避模式的距離

    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private float pauseTimer = 0f;
    private float wobbleTime = 0f;
    private bool isDashing = false;
    private bool isPaused = false;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 side = Vector3.Cross(toPlayer, Vector3.forward);

        // Perlin 抖動擺動
        wobbleTime += Time.deltaTime * wobbleFrequency;
        float wobble = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) - 0.5f;
        Vector3 wobbleOffset = side * wobbleAmplitude * wobble;

        Vector3 finalDirection;

        // ?? 模式切換：攻擊 或 迴避
        if (distanceToPlayer < tooCloseRange)
        {
            // ?? 太近 → 迴避模式（反方向 + 擺動）
            finalDirection = (-toPlayer + wobbleOffset).normalized;
        }
        else
        {
            // ?? 進攻模式（靠近 + 擺動）
            finalDirection = (toPlayer + wobbleOffset).normalized;
        }

        // ?? 暫停邏輯
        if (isPaused)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0) isPaused = false;
            return;
        }

        // ? Dash 模式
        if (isDashing)
        {
            transform.position += finalDirection * dashSpeed * Time.deltaTime;
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
                cooldownTimer = dashCooldown;
            }
        }
        else
        {
            // ?? 平時移動
            transform.position += finalDirection * normalSpeed * Time.deltaTime;
            cooldownTimer -= Time.deltaTime;

            // 偶爾小停頓
            if (Random.value < pauseChance)
            {
                isPaused = true;
                pauseTimer = pauseDuration;
            }

            // ?? 當在「攻擊範圍」內才可能 Dash
            if (cooldownTimer <= 0f && distanceToPlayer < attackRange)
            {
                isDashing = true;
                dashTimer = dashDuration;
            }
        }
    }
}


