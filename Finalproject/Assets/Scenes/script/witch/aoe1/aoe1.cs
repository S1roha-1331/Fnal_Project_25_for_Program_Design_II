using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10f;
     
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth hp=other.GetComponentInParent<playerHealth>();
            hp.takeDamage(damage);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
    }
}
