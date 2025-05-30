using UnityEngine;
using System;

public class weaponUpdate : MonoBehaviour
{
    private playerStats player;
    public weaponStat stat;

    private float statchangePerlevel = .1f;
    public float statchangeParameter = 0f;

    void levelUpdated(int levelUp)
    {
        updateDamage();
        updateDurability();
    }

    void updateDamage()
    {
        statchangeParameter = 1 + (float)Math.Round((player.Level - 1)* statchangePerlevel, 1, MidpointRounding.AwayFromZero);
        stat.weaponDamage = stat.defaultDamage * statchangeParameter;
    }
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
        player.OnLevelChanged += levelUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        player.OnLevelChanged -= levelUpdated;
    }
}
