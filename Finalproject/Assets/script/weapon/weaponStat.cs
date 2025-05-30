using System.Threading;
using UnityEngine;
public enum WeaponGenre
{
    notdefined = 0,
    melee = 1,
    ranged = 2
}

public class weaponStat : MonoBehaviour
{
    

    [Header("Weapon ID")]
    public int weaponID = -1;
    public int weaponLevel = 0;
    public int weaponTag = -1;//determine the order of weapon in player's stock
    public WeaponGenre weaponGenre = WeaponGenre.notdefined;
    [Header("Weapon Dmg")]
    public float weaponDamage = 0f;
    public float defaultDamage = 10f;
    [Header("Weapon CD")]
    public float attackCooldown = 2f;
    public float defaultCooldown = 2f;
    public float weaponRepairCD = 15f;
    public float defaultRepairCD = 15f;
    [Header("Weapon Durability")]
    public float weaponDurability = 0f;
    public float defaultDurability = 50f;
    public float maxDurability = 50f;
    public float downgradePerhit = 5f;
    public bool isbroken = false;

    [Header("")]
    //will use these variable if we have time :D
    public bool attackSword = false;
    public bool isDefaultweapon = false;
    public bool isUltra = false;
    public int maxLevel = 6;

    public weaponOrder order;

    //determine if this is a new extra weapon
    public bool isnewWeapon()
    {
        if(weaponTag == order.latestWeapon && weaponTag >= 0)
        {
            return false;
        }
        else
        {
            weaponTag = (++order.latestWeapon);
            return true;
        }
    }
    //countdown cooldown time
    public void weaponCDUpdate()
    {
        attackCooldown -= Time.deltaTime;
    }
    //countdown weapon repairtime
    public void repairCDUpdate()
    {
        weaponRepairCD -= Time.deltaTime;
    }
    //determine if the weapon is broken or has been repaired
    public void conditioniUpdate()
    {
        if (isbroken && weaponRepairCD <= 0f)
            isbroken = false;
        else if (weaponDurability <= 0f)
        {
            isbroken = true;
            repairCDUpdate();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        order = GameObject.FindWithTag("Player").GetComponent<weaponOrder>();
        weaponDamage = defaultDamage;
        weaponDurability = defaultDurability;
        attackCooldown = defaultCooldown;

        //assign the genre of the weapon
        //if()
        //weaponGenre = WeaponGenre.melee;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
