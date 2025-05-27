using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitbox;
    public void enableHitbox()
    {
        hitbox.SetActive(true);
    }
    public void disableHitbox()
    {
        hitbox.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
