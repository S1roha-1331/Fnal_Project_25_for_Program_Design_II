using UnityEngine;

public class CoinsFly : MonoBehaviour
{
    public int coinsAmount = 5;
    public float moveSpeed = 8f;
    public float smoothTime = 0.5f;

    private Transform player;
    private Vector3 velocity = Vector3.zero;
    private bool isFlying = false;
    private bool hasCollected = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 randomOffset = Random.insideUnitCircle * 5f;
        transform.position += new Vector3(randomOffset.x, randomOffset.y, 0);
        Invoke(nameof(StartFlying), 0.2f);
    }

    void StartFlying()
    {
        isFlying = true;
    }

    void Update()
    {
        if (isFlying && player != null)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                player.position,
                ref velocity,
                smoothTime,
                Mathf.Infinity,
                Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollected && other.CompareTag("Player"))
        {
            hasCollected = true;
            InventoryManager.Instance.AddCoins(coinsAmount);
            Destroy(gameObject);
        }
    }
}
