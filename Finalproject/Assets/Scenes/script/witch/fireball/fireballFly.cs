using UnityEngine;

public class fireballFly : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float accelerationTime = 2f;
    private Vector3 moveDirection;
    private float currentSpeed = 0f;
    private float moveStartTime;
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 targetPosition=player.transform.position;
            moveDirection = (targetPosition - transform.position).normalized;
            if (moveDirection.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float elapsed=Time.time - moveStartTime;
            float t = Mathf.Clamp01(elapsed / accelerationTime);
            currentSpeed=Mathf.Lerp(0,maxSpeed,t);
            transform.position+=moveDirection*currentSpeed*Time.deltaTime;
        }
        

    }
    public void destroySelf()
    {
        Destroy(gameObject);
    }
    public void startMoving()
    {
        isMoving = true;
        moveStartTime = Time.time;
    }
    public void endMoving()
    {
        isMoving=false;
    }
}
