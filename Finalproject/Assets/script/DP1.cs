using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DP1 : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float wobbleAmount = 1f;
    public float wobbleFrequency = 2f;

    public float pathUpdateInterval = 0.5f;  // ? �C�X���s�@����V
    private float pathTimer = 0f;            // �O���N�o�ɶ�
    private Vector3 bestDirection = Vector3.zero;  // �x�s�̪�@����n����V

    private Vector3 lastPosition;  // ?? �s�W�G�O���W�@�V����m
    private attack isAttack;
    private Animator walk;

    void Start()
    {
        lastPosition = transform.position; // ��l�Ʀ�m

    }

    void Update()
    {
        walk=GetComponent<Animator>();
        isAttack= GetComponentInChildren<attack>();
        if (isAttack.isAttack)
        {
            return;
        }
        pathTimer -= Time.deltaTime;


        if (pathTimer <= 0f)
        {
            // ? ���s�p��̨Τ�V
            bestDirection = Vector3.zero;
            float bestValue = float.MaxValue;

            Vector3[] directions = {
                Vector3.up, Vector3.down, Vector3.left, Vector3.right,
                (Vector3.up + Vector3.left).normalized,
                (Vector3.up + Vector3.right).normalized,
                (Vector3.down + Vector3.left).normalized,
                (Vector3.down + Vector3.right).normalized
            };

            foreach (Vector3 dir in directions)
            {
                Vector3 newPos = transform.position + dir * 0.5f;
                float dist = Vector3.Distance(newPos, player.position);
                if (dist < bestValue)
                {
                    bestValue = dist;
                    bestDirection = dir;
                }
            }

            pathTimer = pathUpdateInterval; // ���m�N�o�ɶ�
        }

        // wobble ����
        Vector3 side = Vector3.Cross(bestDirection, Vector3.forward);
        float noise = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) - 0.5f;
        Vector3 wobble = side * noise * wobbleAmount;

        // �̲פ�V�]����u�ۤW�@����n����V�^
        Vector3 finalDir = (bestDirection + wobble).normalized;

        // ����
        transform.position += finalDir * speed * Time.deltaTime;

        // ?? �s�W�G�P�_�y���ܤ�
        Vector3 movement = transform.position - lastPosition;

        if (movement.magnitude < 0.001f)
        {
           walk.SetBool("walk", false);
        }
        else
        {
            walk.SetBool("walk", true);
            if (movement.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (movement.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        lastPosition = transform.position; // ��s�W�@�V����m
    }
}
