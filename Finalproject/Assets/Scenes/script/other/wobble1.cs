using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobble1 : MonoBehaviour
{
    public Transform player;
    public float normalspeed = 5f;
    public float wobbleAmount = 2f;
    public float wobbleFrequency = 4f;

    private float wobbleTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 side = Vector3.Cross(direction, Vector3.forward);
        wobbleTime += Time.deltaTime * wobbleFrequency;
        Vector3 wobbleDirection = side * wobbleAmount * Mathf.Sin(wobbleTime);
        Vector3 finalDirection = (direction + wobbleDirection).normalized;
        transform.position+=finalDirection*Time.deltaTime*normalspeed;
    }
}
