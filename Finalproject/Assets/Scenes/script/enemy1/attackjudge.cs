using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackjudge : MonoBehaviour
{
    private attack Attack;
    private void Start()
    {
        Attack = GetComponentInParent<attack>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack.startAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack.stopAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
