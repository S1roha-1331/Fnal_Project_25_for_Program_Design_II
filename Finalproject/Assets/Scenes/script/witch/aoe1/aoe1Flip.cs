using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe1Flip : MonoBehaviour
{
    private bool facingRight = true; // �w�]���¥k

    // �]�m��V�A�îھ� facingRight ½�ફ��
    public void SetDirection(bool isRight)
    {
        if (facingRight != isRight) // �p�G��V����
        {
            facingRight = isRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // ���� X �b�Y��ӹ�{½��
            transform.localScale = scale;
        }
    }

    void Start()
    {
        
    }
}
