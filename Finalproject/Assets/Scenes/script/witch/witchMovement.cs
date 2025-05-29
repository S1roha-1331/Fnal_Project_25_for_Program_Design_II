using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchMovement : MonoBehaviour
{
    public witchStats witchStats;
    public witchFlip witchFlip;
    public Transform playerTransform;
    public float pathTimer = 1f;
    Vector3 direction = Vector3.zero;
    // Start is called before the first frame update

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        witchFlip = GetComponent<witchFlip>();
    }
    public void moveTo(Vector3 targetPosition)
    {
        direction=(targetPosition-transform.position).normalized;   
    }
    public void stop()
    {
        direction = Vector3.zero;
    }
    

    // Update is called once per frame
    void Update()
    {
       
        transform.position += direction * witchStats.moveSpeed * Time.deltaTime;
        witchFlip.FaceDirection(direction.x);


    }
}
