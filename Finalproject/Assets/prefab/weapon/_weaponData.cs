using UnityEngine;
public enum WeaponGenre
{
    notdefined = 0,
    melee = 1,
    ranged = 2
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Identity")]
    public int weaponID;
    public string weaponName;
    public WeaponGenre weaponGenre;

    [Header("Visual Components")]
    public Sprite weaponIcon;
    public Sprite weaponSprite;
    public RuntimeAnimatorController weaponAnimator;
    public GameObject bulletPrefab;

    [Header("Weapon Stats")]
    public float damage;
    public float fireRate;
    public int magSize;

    [Header("Bullet Stats")]
    public float bulletSpeed;
    public float bulletRadius;
    public float detectRange;


    [Header("")]
    public GameObject hitbox;
}
