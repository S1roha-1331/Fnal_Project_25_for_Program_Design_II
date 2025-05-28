using UnityEngine;

public class AttackIndicator : MonoBehaviour
{
    public PlayerController player; // 拖入你的 Player
    public float radius = 0.01f;       // 距離中心多遠顯示

    void Update()
    {
        Vector2 dir = player.GetAttackDirection();

        if (dir != Vector2.zero)
        {
            // 設定提示器的位置與旋轉
            transform.localPosition = dir.normalized * radius;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            // 沒輸入時隱藏（可選）
            transform.localPosition = Vector3.zero;
        }
    }
}
