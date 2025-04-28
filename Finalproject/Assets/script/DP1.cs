using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DP1 : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float wobbleAmount = 1f;
    public float wobbleFrequency = 2f;

    public float pathUpdateInterval = 0.5f;  // ? 每幾秒更新一次方向
    private float pathTimer = 0f;            // 記錄冷卻時間
    private Vector3 bestDirection = Vector3.zero;  // 儲存最近一次選好的方向

    void Update()
    {
        pathTimer -= Time.deltaTime;

        if (pathTimer <= 0f)
        {
            // ? 重新計算最佳方向
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

            pathTimer = pathUpdateInterval; // 重置冷卻時間
        }

        // wobble 偏移
        Vector3 side = Vector3.Cross(bestDirection, Vector3.forward);
        float noise = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) - 0.5f;
        Vector3 wobble = side * noise * wobbleAmount;

        // 最終方向（持續沿著上一次算好的方向）
        Vector3 finalDir = (bestDirection + wobble).normalized;

        transform.position += finalDir * speed * Time.deltaTime;
    }
}
