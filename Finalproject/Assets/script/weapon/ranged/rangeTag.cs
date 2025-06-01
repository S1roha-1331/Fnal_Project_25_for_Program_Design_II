using UnityEngine;

public class rangeTag : MonoBehaviour
{
    public Transform player;

    private Vector2 playerLast;
    private Vector2 playerNow;
    private Vector2 playerOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        playerLast = player.position; //vectorLast = (Vector2)transform.position - playerLast;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNow = player.position; //vectorNow = (Vector2)transform.position - playerNow;
        playerOffset = playerNow - playerLast;
        //transform.position += (Vector3)(playerOffset);//  - vectorOffset 
        playerLast = playerNow; //vectorLast = vectorNow;
    }
}
