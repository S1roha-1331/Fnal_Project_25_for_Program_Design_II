using UnityEngine;
using System;

public class weaponUpdate : MonoBehaviour
{
    private playerStats player;
    public weaponStat stat;

    //set the parameter to change weapon stat
    private float statchangePerlevel = .1f;
    public float statchangeParameter = 0f;

    //call if player level up
    void levelUpdated(int levelUp)
    {
        updateDamage();
        updateDurability();
    }

    //update weapon damage based on player level
    void updateDamage()
    {
        statchangeParameter = 1 + (float)Math.Round((player.Level - 1)* statchangePerlevel, 1, MidpointRounding.AwayFromZero);
        stat.weaponDamage = stat.defaultDamage * statchangeParameter;
    }
    //update weapon durability based on player level
    void updateDurability()
    {
        stat.maxDurability = stat.defaultDurability * statchangeParameter;
        stat.weaponDurability = stat.maxDurability;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<playerStats>();
        stat = GetComponent<weaponStat>();
        //subscribe OnLevelChanged
        player.OnLevelChanged += levelUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //unsubscribe OnLevelChanged
    private void OnDestroy()
    {
        player.OnLevelChanged -= levelUpdated;
    }
}
