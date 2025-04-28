using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private bool isAttack=false;
    // Start is called before the first frame update
    public void startAttack()
    {
        isAttack=true;
    }
    public void stopAttack()
    {
        isAttack = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack)
        {
            Debug.Log("attack!");
        }
        
    }
}
