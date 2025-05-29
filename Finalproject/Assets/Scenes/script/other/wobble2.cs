using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobble2 : MonoBehaviour
{
    public Transform player;
    public float normalspeed = 3f;
    public float wobbleAmount = 5f;
    public float wobbleFrequency = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction=(player.position-transform.position).normalized;
        Vector3 side=Vector3.Cross(direction, Vector3.forward);
        float noise = Mathf.PerlinNoise(Time.time * wobbleFrequency, 0f) -0.5f;
        Vector3 wobble = side * noise * wobbleAmount;
        Vector3 finalDirection=(wobble+direction).normalized;
        transform.position += Time.deltaTime * finalDirection*normalspeed;
    }
}
