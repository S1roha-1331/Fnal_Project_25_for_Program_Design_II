using Unity.VisualScripting;
using UnityEngine;
//using static Unity.VisualScripting.Round<TInput, TOutput>;

public class player : MonoBehaviour
{
    public int moveSpeed;
    public LayerMask groundLayer;
    public Animator animator;
    private bool cancontrol = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (cancontrol)
        {
            
            float h = Input.GetAxis("Horizontal");
            Debug.Log(h);
            if (Mathf.Abs(h) > 0.05f)
            {   
                
                Vector2 move = new Vector2(h, 0);
                transform.Translate(move * moveSpeed * Time.deltaTime);
                animator.SetBool("run 0", true);
                if (h < 0)
                {
                    GetComponent<Transform>().localScale = new Vector3(-20, 20, 1);
                }
                else
                {
                    GetComponent<Transform>().localScale = new Vector3(20, 20, 1);  
                }

            }
            else
            {
                animator.SetBool("run 0", false);
            }
        }
        else
        {
            animator.SetBool("run 0", false);
        }

    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            cancontrol = true;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            cancontrol = false;
            // Debug.Log("離開地板，不能移動");
        }

    }
}