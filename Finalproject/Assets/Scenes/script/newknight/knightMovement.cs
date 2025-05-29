using UnityEngine;

public class knightMovement : MonoBehaviour
{
    public float pathUpdateInterval = 0.5f;

    public float wobbleAmount = 1f;
    public float wobbleSpeed = 2f;

    private Transform player;
    private knightStats speed;
    private Vector2 currentTargetDirection;
    private float pathTimer;
    private float wobbleOffsetSeed;
    private float moveSpeed;
    private Vector3 lastPosition;
    private knightAttack knightAttack;
    private knightFlip knightFlip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindWithTag("Player").transform;
        wobbleOffsetSeed = Random.Range(0f, 100f);
        speed=GetComponent<knightStats>();
        moveSpeed = speed.moveSpeed;
        knightAttack = GetComponentInChildren<knightAttack>();
        knightFlip = GetComponent<knightFlip>();
    }

    // Update is called once per frame
    public bool isMoving()
    {
        return (transform.position - lastPosition).sqrMagnitude > 0.000001f;
    }
    void Update()
    {
        if (knightAttack.isAttack||speed.isDead) return;
        lastPosition = transform.position;
        pathTimer -=Time.deltaTime;
        if(pathTimer <= 0f)
        {
            Vector2 toPlayer = (player.position - transform.position).normalized;
            currentTargetDirection = toPlayer;
            pathTimer = pathUpdateInterval;
        }
        Vector2 wobble = new Vector2(Mathf.PerlinNoise(Time.time * wobbleSpeed + wobbleOffsetSeed, 0f) - 0.5f, Mathf.PerlinNoise(0f, Time.time * wobbleSpeed + wobbleOffsetSeed) - 0.5f) * wobbleAmount;
        Vector2 finalDirection = (currentTargetDirection + wobble).normalized;
        transform.position += (Vector3)(finalDirection * moveSpeed * Time.deltaTime);
        knightFlip.FaceDirection(finalDirection.x);
    }
}
