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
    public bool attackSword = false;
    public bool isdefaultWeapon = false;

    //will use these variable if we have time :D
    public bool isUltra = false;
    public int maxLevel = 6;

    public weaponOrder order;

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
    public void weaponCDUpdate()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void repairCDUpdate()
    {
        weaponRepairCD -= Time.deltaTime;
    }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
