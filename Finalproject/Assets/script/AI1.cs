using System.Collections;
using System.Collections.Generic;
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

    public float attackRange = 6f;      // �i�J�����Ҧ����d��
    public float tooCloseRange = 2.5f;  // �i�J�j�׼Ҧ����Z��

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

        // Perlin �ݰ��\��
        wobbleTime += Time.deltaTime * wobbleFrequency;
        float wobble = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) - 0.5f;
        Vector3 wobbleOffset = side * wobbleAmplitude * wobble;

        Vector3 finalDirection;

        // ?? �Ҧ������G���� �� �j��
        if (distanceToPlayer < tooCloseRange)
        {
            // ?? �Ӫ� �� �j�׼Ҧ��]�Ϥ�V + �\�ʡ^
            finalDirection = (-toPlayer + wobbleOffset).normalized;
        }
        else
        {
            // ?? �i��Ҧ��]�a�� + �\�ʡ^
            finalDirection = (toPlayer + wobbleOffset).normalized;
        }

        // ?? �Ȱ��޿�
        if (isPaused)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0) isPaused = false;
            return;
        }

        // ? Dash �Ҧ�
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
            // ?? ���ɲ���
            transform.position += finalDirection * normalSpeed * Time.deltaTime;
            cooldownTimer -= Time.deltaTime;

            // �����p���y
            if (Random.value < pauseChance)
            {
                isPaused = true;
                pauseTimer = pauseDuration;
            }

            // ?? ���b�u�����d��v���~�i�� Dash
            if (cooldownTimer <= 0f && distanceToPlayer < attackRange)
            {
                isDashing = true;
                dashTimer = dashDuration;
            }
        }
    }
}


