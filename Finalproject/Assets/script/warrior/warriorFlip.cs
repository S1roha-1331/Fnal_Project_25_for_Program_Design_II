using UnityEngine;

public class warriorFlip : MonoBehaviour
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created1
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
