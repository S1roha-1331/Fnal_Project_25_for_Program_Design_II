using UnityEngine;

public class coinsFly : MonoBehaviour
{
    public int coinsAmount = 5;
    public float moveSpeed = 8f;
    public float smoothTime = 0.5f;

    private Transform player;
    private Vector3 velocity = Vector3.zero;
    private bool isFlying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; ;
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * 5f;
        transform.position += new Vector3(randomOffset.x, randomOffset.y, 0);
        Invoke("startFlying", 0.2f);
    }
    void startFlying()
    {
        isFlying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying && player != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, smoothTime, moveSpeed);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            iventoryManager.instance.addCoins(coinsAmount);
            Destroy(gameObject);
        }
    }
}
