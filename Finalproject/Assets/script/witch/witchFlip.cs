using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchFlip : MonoBehaviour
{
    // Start is called before the first frame update
    public bool facingRight = true;

    public void FaceDirection(float moveX)
    {
        if (moveX > 0 && !facingRight || moveX < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
