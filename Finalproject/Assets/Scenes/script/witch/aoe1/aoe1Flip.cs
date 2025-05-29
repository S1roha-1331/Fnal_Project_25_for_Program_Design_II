using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe1Flip : MonoBehaviour
{
    private bool facingRight = true; // 預設為朝右

    // 設置方向，並根據 facingRight 翻轉物件
    public void SetDirection(bool isRight)
    {
        if (facingRight != isRight) // 如果方向改變
        {
            facingRight = isRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // 改變 X 軸縮放來實現翻轉
            transform.localScale = scale;
        }
    }

    void Start()
    {
        
    }
}
