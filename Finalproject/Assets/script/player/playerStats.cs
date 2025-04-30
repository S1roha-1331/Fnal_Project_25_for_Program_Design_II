using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public float basicHealth;
    public float basicAttack;
    public float level;
    public float healthPerLevel;
    public float exp;
    // Start is called before the first frame update
    public float getMaxHealth()
    {
        return basicHealth+(level-1)*healthPerLevel;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
