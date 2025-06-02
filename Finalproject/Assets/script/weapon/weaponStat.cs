using System.Threading;
using UnityEngine;

public class weaponStat : MonoBehaviour
{
    public weaponControl control;

    [Header("Weapon ID")]
    public int weaponID = -1;
    public int weaponLevel = 0;
    public int weaponTag= -1;//determine the order of weapon in player's stock
    public WeaponGenre weaponGenre = WeaponGenre.notdefined;
    [Header("Weapon Dmg")]
    public float weaponDamage = 0f;
    public float defaultDamage = 10f;
    [Header("Weapon CD")]
    public float attackCooldown = 1f;
    public float defaultCooldown = 1f;
    public float weaponRepairCD = 15f;
    public float defaultRepairCD = 15f;
    [Header("Weapon Durability")]
    public float weaponDurability = 0f;
    public float defaultDurability = 50f;
    public float maxDurability = 50f;
    public float downgradePerhit = 5f;
    public bool isbroken = false;
    [Header("Weapon Range")]
    public float weaponRange = 0f;
    public float defaultRange = 0.5f;

    [Header("")]
    //will use these variable if we have time :D
    public bool attackSword = false;
    public bool isdefaultWeapon = false;
    public bool isUltra = false;
    public int maxLevel = 6;

    public weaponOrder order;

    //determine if this is a new extra weapon
    public bool isnewWeapon()
    {
        if(weaponTag >= 0)//weaponTag == order.latestWeapon && 
        {
            return false;
        }
        else
        {
            weaponTag = ++order.latestWeapon;
            if (order.latestWeapon == order.weaponLimit)
                order.weaponReachedlimit = true;
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
        {
            control.animator.reload();
            isbroken = false;
            weaponDurability = maxDurability;
            weaponRepairCD = defaultRepairCD;
        }
        else if (weaponDurability <= 0f)
        {
            isbroken = true;
            repairCDUpdate();
        }
        else
        {
            isbroken = false;
            weaponRepairCD = defaultRepairCD;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        order = GameObject.FindWithTag("Player").GetComponent<weaponOrder>();
        control = GetComponent<weaponControl>();

        weaponDamage = defaultDamage;
        weaponDurability = defaultDurability;
        attackCooldown = defaultCooldown;
        weaponRepairCD = defaultRepairCD;

        //assign the genre of the weapon
        //if()
        //weaponGenre = WeaponGenre.melee;
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponRepairCD == 0f)
        {
            control.animator.empty();
        }
    }
}
